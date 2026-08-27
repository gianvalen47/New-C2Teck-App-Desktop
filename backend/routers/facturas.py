"""
API routers for facturas (invoices)

Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
Extracted from: SIGECOM\SIGECOM\Interfaces\Ventas\Facturas\frmFactura.vb (1420 líneas)

Campos principales:
- IdFactura (int, PK)
- IdLocacion (int)
- FecDoc (datetime) - Fecha documento
- IdSerieDoc (int) - Serie
- NumDoc (int) - Número
- IdCliente (int) - FK cliente
- CodMon (string) - Código moneda
- IGV (decimal) - % IGV
- TipCambio (decimal)
- TotBruto (decimal)
- TotDscto (decimal)
- TotVenta (decimal)
- TotIGV (decimal)
- TotNeto (decimal)
- Observacion (string)
- Estado (string) - GENERADO | APROBADO | ANULADO | PAGADO

Detalles FacturaDet:
- IdDetalle, IdFactura, Item, CodMer, DesMer, CodUniMed, CanMer, PreMer, DscMer, TotalFila
"""
import logging

from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session

from config import SessionLocal

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/facturas", tags=["Facturas"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[dict])
def list_facturas(
    skip: int = 0,
    limit: int = 100,
    search: str | None = None,
    estado: str | None = None,
    anio: int | None = None,
    mes: int | None = None,
    db: Session = Depends(get_db),
):
    """
    List all facturas with optional filters

    Equivalent to: frmFacturas.Filtrar(anio, mes, estado, ...)
    Filters: search (NumDoc, Cliente), estado, anio, mes
    """
    logger.info(f"Listing facturas: skip={skip}, limit={limit}, estado={estado}, anio={anio}, mes={mes}")

    # TODO: Implement when facturas table is created
    return {
        "message": "Facturas endpoint not yet implemented. Need to create backend models for Factura and FacturaDet.",
        "items": [],
        "total": 0,
    }


@router.get("/{factura_id}", response_model=dict)
def get_factura(factura_id: str, db: Session = Depends(get_db)):
    """
    Get a specific factura by ID (includes detalles)

    Equivalent to: frmFactura.ObtenerRegistro(IdFactura)
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Factura endpoint not yet implemented"
    )


@router.post("", response_model=dict)
def create_factura(factura_data: dict, db: Session = Depends(get_db)):
    """
    Create a new factura

    Equivalent to: frmFactura.Guardar() with insert mode

    Business rules:
    - Cliente requerido
    - Mínimo 1 detalle
    - FecDoc ≤ hoy
    - Número de serie/documento única por locación
    - Totales calculados automáticamente
    - IGV calculado = TotVenta * (IGV% / 100)
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Factura creation not yet implemented"
    )


@router.put("/{factura_id}", response_model=dict)
def update_factura(factura_id: str, factura_data: dict, db: Session = Depends(get_db)):
    """
    Update a factura

    Equivalent to: frmFactura.Guardar() with update mode

    Restrictions:
    - Solo editable si Estado = GENERADO
    - No se puede cambiar número de serie/documento
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Factura update not yet implemented"
    )


@router.delete("/{factura_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_factura(factura_id: str, db: Session = Depends(get_db)):
    """
    Delete a factura (anular)

    Equivalent to: frmFactura.Eliminar() -> Estado = ANULADO
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Factura deletion not yet implemented"
    )


# ============================================================================
# DETALLES DE FACTURA (Sub-resource)
# ============================================================================

@router.get("/{factura_id}/detalles", response_model=list[dict])
def get_factura_detalles(factura_id: str, db: Session = Depends(get_db)):
    """
    Get all detalles for a specific factura

    Equivalent to: frmFactura.ListarDetalles(IdFactura)
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Factura detalles not yet implemented"
    )


@router.post("/{factura_id}/detalles", response_model=dict)
def add_factura_detalle(factura_id: str, detalle_data: dict, db: Session = Depends(get_db)):
    """
    Add a detalle to a factura

    Equivalent to: frmFactura_AgregarDetalle.Guardar()

    Business rules:
    - Mercadería requerida
    - Cantidad > 0
    - Precio > 0
    - Item autonumerado
    - Totales se recalculan automáticamente
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Adding factura detalle not yet implemented"
    )


@router.put("/{factura_id}/detalles/{detalle_id}", response_model=dict)
def update_factura_detalle(factura_id: str, detalle_id: str, detalle_data: dict, db: Session = Depends(get_db)):
    """
    Update a detalle of a factura

    Equivalent to: frmFactura_AgregarDetalle.Guardar() with update mode
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Updating factura detalle not yet implemented"
    )


@router.delete("/{factura_id}/detalles/{detalle_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_factura_detalle(factura_id: str, detalle_id: str, db: Session = Depends(get_db)):
    """
    Delete a detalle from a factura

    Equivalent to: frmFactura_AgregarDetalle.Eliminar()

    Side effects:
    - Si era el último detalle, no se permite eliminar
    - Totales se recalculan automáticamente
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Deleting factura detalle not yet implemented"
    )


# ============================================================================
# CUOTAS DE FACTURA (Sub-resource)
# ============================================================================

@router.get("/{factura_id}/cuotas", response_model=list[dict])
def get_factura_cuotas(factura_id: str, db: Session = Depends(get_db)):
    """
    Get all cuotas (payment plans) for a specific factura

    Equivalent to: frmFactura_Cuotas.Listar()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Factura cuotas not yet implemented"
    )


@router.post("/{factura_id}/cuotas", response_model=dict)
def add_factura_cuota(factura_id: str, cuota_data: dict, db: Session = Depends(get_db)):
    """
    Add a cuota (payment plan) to a factura

    Equivalent to: frmFactura_Cuotas_Nuevo.Guardar()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Adding factura cuota not yet implemented"
    )


# ============================================================================
# FACTURA ELECTRÓNICA (Sub-resource)
# ============================================================================

@router.post("/{factura_id}/enviar-sunat", response_model=dict)
def send_factura_to_sunat(factura_id: str, db: Session = Depends(get_db)):
    """
    Send factura to SUNAT for electronic signature

    Equivalent to: frmFactura_FacturaElectronica.EnviarSUNAT()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Sending factura to SUNAT not yet implemented"
    )


@router.get("/{factura_id}/cdr", response_model=dict)
def get_factura_cdr(factura_id: str, db: Session = Depends(get_db)):
    """
    Get CDR (Comprobante de Recepción) status from SUNAT

    Equivalent to: frmFactura_Electronica_ActualizarCDR.Consultar()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Getting factura CDR not yet implemented"
    )
