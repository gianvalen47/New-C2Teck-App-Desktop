"""
API routers for órdenes de compra (purchase orders)

Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
Extracted from: SIGECOM\SIGECOM\Interfaces\Compras\OrdenCompra\frmComOrdenCompra.vb (1300 líneas)

Campos principales:
- IdOrdenCompra (int, PK)
- IdLocacion (int)
- FecDoc (datetime) - Fecha documento
- IdSerieDoc (int) - Serie
- NumDoc (int) - Número
- IdProveedor (int) - FK proveedor
- Observacion (string)
- TotBruto (decimal)
- IGV (decimal) - % o monto
- TotIGV (decimal)
- TotNeto (decimal)
- FecVencimiento (datetime)
- Estado (string) - GENERADO | RECIBIDO | ANULADO | PAGADO

Detalles ComOrdenCompraDet:
- IdDetalle, IdOrdenCompra, Item, CodMer, DesMer, CanMer, PreMer, DscMer, TotalFila, CanRecibida
"""
import logging

from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session

from config import SessionLocal
from legacy_adapter import (
    is_legacy_source_enabled,
    list_purchases_legacy,
    get_purchase_legacy,
)

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/ordenes-compra", tags=["Órdenes de Compra"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[dict])
def list_ordenes_compra(
    skip: int = 0,
    limit: int = 100,
    search: str | None = None,
    estado: str | None = None,
    proveedor_id: int | None = None,
    anio: int | None = None,
    mes: int | None = None,
    db: Session = Depends(get_db),
):
    """
    List all órdenes de compra with optional filters

    Equivalent to: frmComOrdenesCompra.Filtrar(estado, proveedor, anio, mes, ...)
    Filters: search (NumDoc, Proveedor), estado, proveedor_id, anio, mes
    """
    logger.info(f"Listing ordenes compra: skip={skip}, limit={limit}, estado={estado}, proveedor={proveedor_id}")

    if is_legacy_source_enabled():
        try:
            data = list_purchases_legacy(skip=skip, limit=limit, estado=estado)
            if isinstance(data, dict) and "items" in data:
                return data["items"]
            elif isinstance(data, list):
                return data
            else:
                return [data] if data else []
        except Exception as exc:
            logger.error(f"Failed to fetch ordenes compra from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Start sigecoom-wcf-adapter.exe or check SIGECOM_LEGACY_ADAPTER_BASE_URL.",
            )

    # TODO: Implement local SQLite version when OrdeneCompra model is created
    return {
        "message": "Órdenes de Compra endpoint not yet fully implemented. Using legacy adapter.",
        "items": [],
        "total": 0,
    }


@router.get("/{orden_id}", response_model=dict)
def get_orden_compra(orden_id: str, db: Session = Depends(get_db)):
    """
    Get a specific orden de compra by ID (includes detalles)

    Equivalent to: frmComOrdenCompra.ObtenerRegistro(IdOrdenCompra)
    """
    if is_legacy_source_enabled():
        try:
            return get_purchase_legacy(orden_id)
        except Exception as exc:
            logger.error(f"Failed to fetch orden compra {orden_id} from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}",
            )

    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Orden de compra endpoint not yet fully implemented"
    )


@router.post("", response_model=dict)
def create_orden_compra(orden_data: dict, db: Session = Depends(get_db)):
    """
    Create a new orden de compra

    Equivalent to: frmComOrdenCompra.Guardar() with insert mode

    Business rules:
    - Proveedor requerido
    - Mínimo 1 detalle
    - FecDoc ≤ hoy
    - FecVencimiento > FecDoc
    - Número de serie/documento única por locación
    - Totales calculados automáticamente
    - IGV calculado automáticamente
    - Stock debe ser suficiente en almacén
    """
    if is_legacy_source_enabled():
        raise HTTPException(
            status_code=status.HTTP_403_FORBIDDEN,
            detail="Cannot create órdenes de compra when using legacy SIGECOM adapter. "
                   "Use legacy system directly."
        )

    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Orden de compra creation not yet implemented"
    )


@router.put("/{orden_id}", response_model=dict)
def update_orden_compra(orden_id: str, orden_data: dict, db: Session = Depends(get_db)):
    """
    Update an orden de compra

    Equivalent to: frmComOrdenCompra.Guardar() with update mode

    Restrictions:
    - Solo editable si Estado = GENERADO o PENDIENTE
    - No se puede cambiar número de serie/documento
    - No se puede cambiar proveedor si ya recibió parte
    """
    if is_legacy_source_enabled():
        raise HTTPException(
            status_code=status.HTTP_403_FORBIDDEN,
            detail="Cannot update órdenes de compra when using legacy SIGECOM adapter. "
                   "Use legacy system directly."
        )

    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Orden de compra update not yet implemented"
    )


@router.delete("/{orden_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_orden_compra(orden_id: str, db: Session = Depends(get_db)):
    """
    Delete an orden de compra (anular)

    Equivalent to: frmComOrdenCompra.Eliminar() -> Estado = ANULADO
    """
    if is_legacy_source_enabled():
        raise HTTPException(
            status_code=status.HTTP_403_FORBIDDEN,
            detail="Cannot delete órdenes de compra when using legacy SIGECOM adapter. "
                   "Use legacy system directly."
        )

    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Orden de compra deletion not yet implemented"
    )


# ============================================================================
# DETALLES DE ORDEN DE COMPRA (Sub-resource)
# ============================================================================

@router.get("/{orden_id}/detalles", response_model=list[dict])
def get_orden_detalles(orden_id: str, db: Session = Depends(get_db)):
    """
    Get all detalles for a specific orden de compra

    Equivalent to: frmComOrdenCompra.ListarDetalles(IdOrdenCompra)
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Orden de compra detalles not yet implemented"
    )


@router.post("/{orden_id}/detalles", response_model=dict)
def add_orden_detalle(orden_id: str, detalle_data: dict, db: Session = Depends(get_db)):
    """
    Add a detalle to an orden de compra

    Equivalent to: frmComOrdenCompraDet.Guardar()

    Business rules:
    - Mercadería requerida
    - Cantidad > 0
    - Precio > 0
    - Item autonumerado
    - Totales se recalculan automáticamente
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Adding orden detalle not yet implemented"
    )


@router.put("/{orden_id}/detalles/{detalle_id}", response_model=dict)
def update_orden_detalle(orden_id: str, detalle_id: str, detalle_data: dict, db: Session = Depends(get_db)):
    """
    Update a detalle of an orden de compra
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Updating orden detalle not yet implemented"
    )


@router.delete("/{orden_id}/detalles/{detalle_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_orden_detalle(orden_id: str, detalle_id: str, db: Session = Depends(get_db)):
    """
    Delete a detalle from an orden de compra

    Side effects:
    - Si era el último detalle, no se permite eliminar
    - Si ya fue recibida cantidad, se ajusta automáticamente
    - Totales se recalculan automáticamente
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Deleting orden detalle not yet implemented"
    )


# ============================================================================
# RECEPCIÓN DE ORDEN DE COMPRA (Sub-resource)
# ============================================================================

@router.post("/{orden_id}/recibir", response_model=dict)
def receive_orden_compra(orden_id: str, cantidad_data: dict, db: Session = Depends(get_db)):
    """
    Receive (partial or full) an orden de compra

    Equivalent to: frmComOrdenCompra.RecebirMercaderia()

    Business rules:
    - Cantidad recibida ≤ Cantidad solicitada
    - Actualiza stock en almacén
    - Cambia Estado a RECIBIDO si cantidad recibida = cantidad solicitada
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Receiving orden de compra not yet implemented"
    )


@router.post("/{orden_id}/cancelar", response_model=dict)
def cancel_orden_compra(orden_id: str, db: Session = Depends(get_db)):
    """
    Cancel an orden de compra (mark as ANULADO)

    Equivalent to: frmComOrdenCompra.Cancelar()

    Restrictions:
    - Solo si Estado = GENERADO
    - Si fue parcialmente recibida, primero hay que revertir recepción
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Canceling orden de compra not yet implemented"
    )
