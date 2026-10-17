

export function GmroiCostosReport() { 
    return 
    <Report>
        <Options name="Tipo" values={["Resumen x Rubro", "Resumen x Unidad Negocio", "Detallado x Mercadería"]} />
        <Box title="Rango de Fechas"><Dates start="01/01/2026" />
        </Box><div className={row}>
            <Select label="Oficina:" />
            <Select label="Almacén:" />
            <Select label="Rubro:" />
            </div>
            <div className="flex justify-center">
                <Options name="Exportar" values={["Pantalla", "Excel"]} />
                </div>
                </Report>;
            }
