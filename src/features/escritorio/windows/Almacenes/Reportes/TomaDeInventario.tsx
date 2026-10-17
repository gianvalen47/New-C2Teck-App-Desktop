

export function TomaInventarioReport() { 
    return <ReportFrame>
        <fieldset className="border border-slate-400 p-2">
            <legend className="text-[11px] font-bold">INVENTARIO</legend>
            <div className="grid grid-cols-3 gap-3">
                <div className="space-y-2">
                    <Stack label="Stock a la Fecha:">
                        <input type="date" className={inp} defaultValue="2026-09-18"/>
                        </Stack>
                        <Stack label="Oficina:"><Select><option>LIMA</option></Select></Stack>
                        <Stack label="Almacén:"><Select><option>COMERCIAL</option></Select></Stack>
                        <Stack label="Tipo Motor:"><Select/></Stack>
                        <Stack label="Modelo:"><Select/></Stack>
                        <Stack label="Rubro:"><Select/></Stack>
                        <Stack label="Clase:"><Select/></Stack>
                        </div><div className="space-y-2">
                            <Check label="Ordenar por Ubicación"/>
                            <fieldset className="border border-slate-400 p-2">
                                <legend className="text-[11px] font-bold">Mostrar Stock</legend>
                                {["Con Stock","Sin Stock","Físico","Con Disponible","Sin Disponible"].map((x,i)=><Choice key={x} name="toma-m" label={x} defaultChecked={!i}/>)}
                                </fieldset>
                                <fieldset className="border border-slate-400 p-2">
                                    <legend className="text-[11px] font-bold">Exportar</legend>
                                    <Choice name="toma-e" label="Pantalla" defaultChecked/>
                                    <Choice name="toma-e" label="Excel"/>
                                    <Choice name="toma-e" label="Exportar Código de Barras"/>
                                    </fieldset>
                                    </div><div className="space-y-2">
                                        <fieldset className="border border-slate-400 p-2">
                                            <legend className="text-[11px] font-bold">Tipo de Stock</legend>
                                            {["Todos","Todos sin Ceros","Ceros","Positivos","Negativos","Bajo el Mínimo","Bajo el Máximo","Sobra y Falta"].map((x,i)=><Choice key={x} name="toma-s" label={x} defaultChecked={!i}/>)}</fieldset>
                                            <fieldset className="border border-slate-400 p-2">
                                                <legend className="text-[11px] font-bold">Ubicación</legend>
                                                <Choice name="toma-u" label="Todos" defaultChecked/>
                                                <Choice name="toma-u" label="Sin Ubicación"/>
                                                <Choice name="toma-u" label="Por Ubicación"/>
                                                </fieldset>
                                                </div>
                                                </div>
                                                </fieldset>
                                                </ReportFrame>; }
