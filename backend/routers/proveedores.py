"""
API routers for proveedores (suppliers)

Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
Extracted from: SIGECOM\SIGECOM\Interfaces\Tablas\Compras\Proveedores\frmProveedor.vb (1691 líneas)

Campos principales del formulario VB.NET:
- IdProveedor (int, PK)
- CodProveedor (string, UK)
- DesProveedor (string) - Nombre
- NroRUC (string)
- Contacto (string)
- Telefono (string)
- Email (string)
- DirProveedor (string) - Dirección
- Estado (int) - Activo/Inactivo
- Observacion (string)
- CondicionPago (string)

Relaciones:
- ContactoProveedor (múltiples)
- CuentasPago (múltiples)
"""
import logging
import uuid

from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session

from config import SessionLocal

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/proveedores", tags=["Proveedores"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


# Placeholder schemas (será reemplazado cuando se implementen modelos)
class ProveedorRead:
    id: str
    codigo: str
    nombre: str
    ruc: str
    contacto: str | None
    telefono: str | None
    email: str | None
    direccion: str | None
    active: int
    condicion_pago: str | None


@router.get("", response_model=list[dict])
def list_proveedores(
    skip: int = 0,
    limit: int = 100,
    search: str | None = None,
    active: bool | None = None,
    db: Session = Depends(get_db),
):
    """
    List all proveedores (suppliers)

    Equivalent to: frmProveedores.Listar()
    Filters: search (CodProveedor, DesProveedor), active (Estado)
    """
    logger.info(f"Listing proveedores: skip={skip}, limit={limit}, search={search}")

    # TODO: Implement when proveedores table is created
    # For now, return empty list with message
    return {
        "message": "Proveedores endpoint not yet implemented. Need to create backend/models/ProveedorModel and legacy_adapter functions.",
        "items": [],
        "total": 0,
    }


@router.get("/{proveedor_id}", response_model=dict)
def get_proveedor(proveedor_id: str, db: Session = Depends(get_db)):
    """
    Get a specific proveedor by ID

    Equivalent to: frmProveedor.ObtenerRegistro(IdProveedor)
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Proveedor endpoint not yet implemented"
    )


@router.post("", response_model=dict)
def create_proveedor(proveedor_data: dict, db: Session = Depends(get_db)):
    """
    Create a new proveedor

    Equivalent to: frmProveedor.Guardar() with insert mode
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Proveedor creation not yet implemented"
    )


@router.put("/{proveedor_id}", response_model=dict)
def update_proveedor(proveedor_id: str, proveedor_data: dict, db: Session = Depends(get_db)):
    """
    Update a proveedor

    Equivalent to: frmProveedor.Guardar() with update mode
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Proveedor update not yet implemented"
    )


@router.delete("/{proveedor_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_proveedor(proveedor_id: str, db: Session = Depends(get_db)):
    """
    Delete a proveedor (soft delete - mark as inactive)

    Equivalent to: frmProveedor.Eliminar()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Proveedor deletion not yet implemented"
    )


# ============================================================================
# CONTACTOS DE PROVEEDOR (Sub-resource)
# ============================================================================

@router.get("/{proveedor_id}/contactos", response_model=list[dict])
def list_proveedor_contactos(proveedor_id: str, db: Session = Depends(get_db)):
    """
    List all contactos (people) for a specific proveedor

    Equivalent to: frmProveedor.ListarContactos()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Proveedor contactos not yet implemented"
    )


@router.post("/{proveedor_id}/contactos", response_model=dict)
def add_proveedor_contacto(proveedor_id: str, contacto_data: dict, db: Session = Depends(get_db)):
    """
    Add a contacto to a proveedor

    Equivalent to: frmProveedor_AgregarContacto.Guardar()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Adding proveedor contacto not yet implemented"
    )


# ============================================================================
# CUENTAS DE PAGO (Sub-resource)
# ============================================================================

@router.get("/{proveedor_id}/cuentas-pago", response_model=list[dict])
def list_proveedor_cuentas_pago(proveedor_id: str, db: Session = Depends(get_db)):
    """
    List all payment accounts for a specific proveedor

    Equivalent to: frmProveedor.ListarCuentasPago()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Proveedor cuentas de pago not yet implemented"
    )


@router.post("/{proveedor_id}/cuentas-pago", response_model=dict)
def add_proveedor_cuenta_pago(proveedor_id: str, cuenta_data: dict, db: Session = Depends(get_db)):
    """
    Add a payment account to a proveedor

    Equivalent to: frmProveedor_AgregarCuentaPago.Guardar()
    """
    raise HTTPException(
        status_code=status.HTTP_501_NOT_IMPLEMENTED,
        detail="Adding proveedor cuenta de pago not yet implemented"
    )
