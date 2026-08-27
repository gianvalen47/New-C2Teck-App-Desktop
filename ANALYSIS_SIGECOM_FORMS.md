# Análisis de Formularios SIGECOM VB.NET → Estructura Python/React

## Resumen Ejecutivo
Análisis de formularios VB.NET del SIGECOM original para mapear lógica de negocio a endpoints REST Python/FastAPI y componentes React. El objetivo es que el frontend React consuma datos REALES del SIGECOM VB.NET original a través del adaptador ASP.NET.

---

## 1. MÓDULO CLIENTES (Ventas/Tablas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Tablas/Ventas/Clientes/frmCliente.vb` (2057 líneas)

### WCF Services Consumidos
```vb
- MaestroClient
- ClienteServiceClient
- ContactoServiceClient
- DireccionFiscalServiceClient
- LocacionClienteServiceClient
- VendedorClienteServiceClient
- CondicionPagoClienteServiceClient
- SeguridadClient
- UsuarioClienteServiceClient
- PersonaServiceClient
```

### Campos de Cliente
```
IdCliente              (int, PK)
DesCli                 (string) - Nombre cliente
IdTipoCliente          (int) - FK tipo cliente
IdTipoCon              (int) - FK tipo contribuyente
TipCon                 (string) - Tipo contribuyente
NroDoc                 (string) - RUC
AbrCli                 (string) - Abreviatura
DueCli                 (string) - Dueño/Representante
DniCli                 (string) - DNI
TelCli                 (string) - Teléfono
FaxCli                 (string) - Fax
Email                  (string) - Email
UrlCli                 (string) - URL
NumCta                 (string) - Número de cuenta
DiaPago                (int) - Día de pago
HoraPago               (string) - Hora de pago
CodSec                 (string) - Código sector
ListaCli               (bool) - En lista de precios
AprCli                 (bool) - Aprobado
Estado                 (int) - Activo/Inactivo
Ubigeo                 (string) - UBIGEO
DirCli                 (string) - Dirección
DueCli                 (string) - Dueño
ObsCli                 (string) - Observaciones
```

### Tabs/Secciones (Relaciones)
1. **Contactos** → `ContactoService` (múltiples por cliente)
2. **Direcciones Fiscales** → `DireccionFiscalService`
3. **Locaciones** → `LocacionClienteService`
4. **Condiciones de Pago** → `CondicionPagoClienteService`
5. **Vendedores** → `VendedorClienteService`
6. **Monedas** → Múltiples monedas por cliente
7. **Usuarios** → `UsuarioClienteService`

### Métodos CRUD
- `ObtenerRegistro()` - GET cliente
- `Guardar()` - POST/PUT cliente
- `Eliminar()` - DELETE cliente
- `listaContactos()` - GET contactos asociados
- `mostrarContacto()` - GET contacto
- `listaLocaciones()` - GET locaciones

---

## 2. MÓDULO GUÍAS DE REMISIÓN (Ventas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Ventas/Guías/Guía de Remisión/frmGuiaRemision.vb` (1454 líneas)

### WCF Services
```vb
- MaestroService.MaestroClient
- GuiaRemisionService.GuiaRemisionServiceClient
- GuiaRemisionDetService.GuiaRemisionDetServiceClient
- LocacionClienteService.LocacionClienteServiceClient
- ContactoService.ContactoServiceClient
- ClienteService.ClienteServiceClient
- SeguridadService.SeguridadClient
- DireccionFiscalService.DireccionFiscalServiceClient
- MercaderiaService.MercaderiaServiceClient
```

### Campos de Guía Remisión (Cabecera)
```
IdGuia                 (int, PK)
IdLocacion             (int) - Ubicación/oficina
FecDoc                 (datetime) - Fecha documento
IdSerieDoc             (int) - Serie del documento
NumDoc                 (int) - Número del documento
IdCliente              (int) - FK cliente
IdLocCli               (int) - FK locación cliente
IdFiscal               (int) - FK dirección fiscal
CodMot                 (string) - Código motivo traslado
NumJob                 (string) - Número de orden
PtoPartida             (string) - Punto de partida
PtoLlegada             (string) - Punto de llegada
CodMon                 (string) - Código moneda
IGV                    (decimal) - % IGV
TipCambio              (decimal) - Tipo de cambio
TotFlete               (decimal) - Total flete
TotEmbarque            (decimal) - Total embarque
TotBruto               (decimal) - Total bruto
TotDscto               (decimal) - Total descuento
TotVenta               (decimal) - Total venta
TotIGV                 (decimal) - Total IGV
TotNeto                (decimal) - Total neto
NumOrden               (string) - Número de orden
IdCotizacion           (int) - FK cotización
Observacion            (string) - Observaciones
PesoBruto              (decimal) - Peso bruto
CodUniMedPeso          (string) - Código unidad medida peso
NumeroBultos           (int) - Número de bultos
FecTraslado            (datetime) - Fecha traslado
CodModo                (string) - Código modo traslado
Estado                 (string) - Estado (GENERADO, APROBADO, ANULADO, CREDITOS)
```

### Campos de Detalle (GuiaRemisionDet)
```
IdDetalle              (int, PK)
IdGuia                 (int) - FK guía
Item                   (int) - Número de línea
CodMer                 (string) - Código mercadería
DesMer                 (string) - Descripción
CodUniMed              (string) - Unidad de medida
CanMer                 (decimal) - Cantidad
PreMer                 (decimal) - Precio unitario
DscMer                 (decimal) - Descuento por línea
TotalFila              (decimal) - Total línea
```

### Métodos CRUD
- `Filtrar(anio, mes, idLocacion, idSerieDoc, idCliente, estado, numDoc)` - LIST con filtros
- `ObtenerRegistro()` - GET guía
- `Guardar()` - POST/PUT guía
- `Eliminar()` - DELETE guía
- `AgregarDetalle()` - POST detalle
- `ModificarDetalle()` - PUT detalle
- `EliminarDetalle()` - DELETE detalle

### Validaciones Clave
- Feccha documento ≤ hoy
- Cliente requerido
- Al menos 1 detalle
- Totales correctos (calculados desde detalles)
- Estado flujo: GENERADO → APROBADO → (ANULADO | CREDITOS)

---

## 3. MÓDULO FACTURAS (Ventas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Ventas/Facturas/frmFactura.vb` (1420 líneas)

### WCF Services
```vb
- FacturaService.FacturaServiceClient
- FacturaDetService.FacturaDetServiceClient
- ClienteService.ClienteServiceClient
- MercaderiaService.MercaderiaServiceClient
```

### Campos de Factura (Estructura similar a Guía)
```
IdFactura              (int, PK)
IdLocacion             (int)
FecDoc                 (datetime)
IdSerieDoc             (int)
NumDoc                 (int)
IdCliente              (int)
CodMon                 (string)
IGV                    (decimal)
TipCambio              (decimal)
TotBruto               (decimal)
TotDscto               (decimal)
TotVenta               (decimal)
TotIGV                 (decimal)
TotNeto                (decimal)
Observacion            (string)
Estado                 (string) - GENERADO | APROBADO | ANULADO | PAGADO
```

### Campos de Detalle (FacturaDet)
```
IdDetalle              (int, PK)
IdFactura              (int)
Item                   (int)
CodMer                 (string)
DesMer                 (string)
CodUniMed              (string)
CanMer                 (decimal)
PreMer                 (decimal)
DscMer                 (decimal)
TotalFila              (decimal)
```

---

## 4. MÓDULO BOLETAS (Ventas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Ventas/Boletas/frmBoleta.vb` (1337 líneas)

### Estructura
- Similar a Factura pero para operaciones sin cliente específico
- Campos iguales (IdBoleta, FecDoc, NumDoc, etc.)
- Detalles igual estructura

---

## 5. MÓDULO PRODUCTOS (Almacén/Tablas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Tablas/Almacen/Productos/frmProducto.vb` (1356 líneas)

### Campos de Producto
```
IdProducto             (int, PK)
CodProd                (string, UK) - Código único
DesProd                (string) - Descripción
TipProd                (string) - Tipo producto
PreCosto               (decimal) - Precio costo
PreVenta               (decimal) - Precio venta
CodUniMed              (string) - Unidad medida
Stock                  (decimal) - Stock actual
StockMin               (decimal) - Stock mínimo
StockMax               (decimal) - Stock máximo
ProveeMercaderia       (string) - FK proveedor
Estado                 (int) - Activo/Inactivo
Observacion            (string)
CodSec                 (string) - Sector
CodLinea               (string) - Línea
```

### Relaciones
- **Locaciones de Producto** → Distribuido por locaciones
- **Modelos de Motor** (si es motor)
- **Imágenes** → Múltiples fotos

---

## 6. MÓDULO MERCADERÍAS (Almacén/Tablas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Tablas/Almacen/Mercaderias/frmMercaderia.vb` (967 líneas)

### Campos
```
IdMercaderia           (int, PK)
CodMercaderia          (string, UK)
DesMercaderia          (string)
CodUniMed              (string)
PreCosto               (decimal)
PreVenta               (decimal)
Stock                  (decimal)
StockMin               (decimal)
StockMax               (decimal)
Estado                 (int)
Observacion            (string)
```

---

## 7. MÓDULO VALES (Almacén/Movimientos)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Almacen/Movimientos/Vales/frmVale.vb` (974 líneas)

### Campos de Vale
```
IdVale                 (int, PK)
IdLocacion             (int)
FecDoc                 (datetime)
IdSerieDoc             (int)
NumDoc                 (int)
IdCliente              (int)
Observacion            (string)
TotBruto               (decimal)
TotDscto               (decimal)
TotVenta               (decimal)
Estado                 (string) - GENERADO | ANULADO
```

### Campos de Detalle (ValeDet)
```
IdDetalle              (int)
IdVale                 (int)
Item                   (int)
CodMer                 (string)
DesMer                 (string)
CanMer                 (decimal)
PreMer                 (decimal)
DscMer                 (decimal)
TotalFila              (decimal)
```

---

## 8. MÓDULO ORDEN DE COMPRA (Compras)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Compras/OrdenCompra/frmComOrdenCompra.vb` (1300 líneas)

### Campos de Orden Compra
```
IdOrdenCompra          (int, PK)
IdLocacion             (int)
FecDoc                 (datetime)
IdSerieDoc             (int)
NumDoc                 (int)
IdProveedor            (int) - FK proveedor
Observacion            (string)
TotBruto               (decimal)
IGV                    (decimal)
TotIGV                 (decimal)
TotNeto                (decimal)
FecVencimiento         (datetime)
Estado                 (string) - GENERADO | RECIBIDO | ANULADO | PAGADO
```

### Campos de Detalle
```
IdDetalle              (int)
IdOrdenCompra          (int)
Item                   (int)
CodMer                 (string)
DesMer                 (string)
CanMer                 (decimal)
PreMer                 (decimal)
DscMer                 (decimal)
TotalFila              (decimal)
CanRecibida            (decimal) - Cantidad recibida
```

---

## 9. MÓDULO PROVEEDOR (Compras/Tablas)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Tablas/Compras/Proveedores/frmProveedor.vb` (1691 líneas)

### Campos de Proveedor
```
IdProveedor            (int, PK)
CodProveedor           (string, UK)
DesProveedor           (string)
NroRUC                 (string)
Contacto               (string)
Telefono               (string)
Email                  (string)
DirProveedor           (string)
Estado                 (int) - Activo/Inactivo
Observacion            (string)
CondicionPago          (string)
```

### Relaciones
- **Contactos** → Múltiples personas
- **Cuentas de Pago** → Múltiples métodos pago

---

## 10. MÓDULO UBICACIONES (Almacén)

### Archivo Principal
- `SIGECOM/SIGECOM/Interfaces/Almacen/Ubicaciones/frmUbicaciones.vb`

### Campos de Ubicación
```
IdUbicacion            (int, PK)
CodUbicacion           (string, UK)
DesUbicacion           (string)
Pasillo                (string)
Estante                (string)
Fila                   (string)
Columna                (string)
Nivel                  (string)
CapacidadMaxima        (decimal)
OcupacidadActual       (decimal)
Estado                 (int)
```

---

## Mapeo a Endpoints REST Python/FastAPI

### Estructura de Endpoints

```python
# CLIENTES
GET    /api/v1/clients                      # list_clients(skip, limit, search)
GET    /api/v1/clients/{client_id}          # get_client(client_id)
POST   /api/v1/clients                      # create_client(client_data)
PUT    /api/v1/clients/{client_id}          # update_client(client_id, client_data)
DELETE /api/v1/clients/{client_id}          # delete_client(client_id)

# GUÍAS DE REMISIÓN
GET    /api/v1/guias-remision               # list_guias(filters...)
GET    /api/v1/guias-remision/{id}          # get_guia(id)
POST   /api/v1/guias-remision               # create_guia(guia_data)
PUT    /api/v1/guias-remision/{id}          # update_guia(id, guia_data)
DELETE /api/v1/guias-remision/{id}          # delete_guia(id)

# DETALLES GUÍA
GET    /api/v1/guias-remision/{id}/detalles        # get_guia_detalles(id)
POST   /api/v1/guias-remision/{id}/detalles        # add_guia_detalle(id, detalle_data)
PUT    /api/v1/guias-remision/{id}/detalles/{det_id}  # update_guia_detalle(...)
DELETE /api/v1/guias-remision/{id}/detalles/{det_id}  # delete_guia_detalle(...)

# FACTURAS
GET    /api/v1/facturas                     # list_facturas(filters...)
GET    /api/v1/facturas/{id}                # get_factura(id)
POST   /api/v1/facturas                     # create_factura(factura_data)
PUT    /api/v1/facturas/{id}                # update_factura(id, factura_data)
DELETE /api/v1/facturas/{id}                # delete_factura(id)

# PRODUCTOS
GET    /api/v1/productos                    # list_productos(filters...)
GET    /api/v1/productos/{id}               # get_producto(id)
POST   /api/v1/productos                    # create_producto(producto_data)
PUT    /api/v1/productos/{id}               # update_producto(id, producto_data)
DELETE /api/v1/productos/{id}               # delete_producto(id)

# PROVEEDORES
GET    /api/v1/proveedores                  # list_proveedores(filters...)
GET    /api/v1/proveedores/{id}             # get_proveedor(id)
POST   /api/v1/proveedores                  # create_proveedor(proveedor_data)
PUT    /api/v1/proveedores/{id}             # update_proveedor(id, proveedor_data)

# ORDEN DE COMPRA
GET    /api/v1/ordenes-compra                # list_ordenes_compra(filters...)
GET    /api/v1/ordenes-compra/{id}           # get_orden_compra(id)
POST   /api/v1/ordenes-compra                # create_orden_compra(orden_data)
PUT    /api/v1/ordenes-compra/{id}           # update_orden_compra(id, orden_data)

# UBICACIONES
GET    /api/v1/ubicaciones                   # list_ubicaciones(filters...)
GET    /api/v1/ubicaciones/{id}              # get_ubicacion(id)
POST   /api/v1/ubicaciones                   # create_ubicacion(ubicacion_data)
PUT    /api/v1/ubicaciones/{id}              # update_ubicacion(id, ubicacion_data)
```

---

## Patrón de Normalización de Datos

Para cada entity, aplicar transformación:

```python
def normalize_client(raw_data: dict) -> dict:
	"""Normaliza datos desde WCF a JSON API"""
	return {
		"id": str(raw_data.get("IdCliente")),
		"name": str(raw_data.get("DesCli", "")),
		"ruc": str(raw_data.get("NroDoc", "")),
		"address": str(raw_data.get("DirCli", "")),
		"phone": str(raw_data.get("TelCli", "")),
		"email": str(raw_data.get("Email", "")),
		"active": bool(raw_data.get("Estado", 0)),
		# ... más campos
	}
```

---

## Validaciones de Negocio

### Clientes
- RUC único
- Email formato válido
- Teléfono formato válido
- Estado: Activo/Inactivo

### Guías de Remisión
- Fecha ≤ hoy
- Cliente requerido
- Mínimo 1 detalle
- Totales = sum(detalles)
- IGV calculado automáticamente
- Estados válidos: GENERADO, APROBADO, ANULADO, CREDITOS

### Facturas
- Igual que guías
- Número de serie/documento único por locación
- Si pagada, no editable

### Órdenes de Compra
- Proveedor requerido
- Mínimo 1 detalle
- Fecha vencimiento > fecha documento
- Stock disponible en almacén

---

## Próximos Pasos

1. ✅ Crear routers Python para cada módulo
2. ✅ Implementar normalizadores de datos
3. ✅ Crear pydantic schemas para validación
4. ✅ Tests de integración con adaptador legacy
5. ✅ Componentes React para consumir datos
6. ✅ Validaciones de negocio en backend
7. ⬜ Implementar cálculos automáticos (totales, IGV, etc.)
8. ⬜ Auditoría de cambios
9. ⬜ Historial de estados
10. ⬜ Reportes

