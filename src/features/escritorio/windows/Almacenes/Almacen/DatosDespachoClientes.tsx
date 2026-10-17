

export function DatosDespachoWindow() {
  const cols: Col[] = ["Cliente", "Lugar Entrega", "Cita", "Tiempo At.", "Tipo Almacen", "Doc", "Horario Atenc", "Dia Atencion", "Contacto", "Zona", "Prioridad", "Observacion"].map((label, i) => ({ key: `c${i}`, label }));
  return 
  <ListShell footer="Registros : 0" toolbar={<StandardToolbar />} 
  filters={<>
    <Stack label="Descripción del Cliente" className="w-[285px]">
        <input className={inp} />
        </Stack>
        <Stack label="Ruc" className="w-[105px]">
            <input className={inp} />
            </Stack>
            <SearchButton />
  </>}><LegacyGrid cols={cols} rows={[]} minRows={3} />
  </ListShell>;
}