"""
API routers for purchase register (Registro de Compras)

Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
"""
import logging
import uuid

from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session

from config import SessionLocal
from models import PurchaseRegisterModel
from schemas import (
    PurchaseRegisterCreate,
    PurchaseRegisterRead,
    PurchaseRegisterUpdate,
)
from legacy_adapter import (
    is_legacy_source_enabled,
    list_purchases_legacy,
    get_purchase_legacy,
)

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/purchases", tags=["Purchases"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[PurchaseRegisterRead])
def list_purchase_registers(
    status_filter: str | None = None,
    document_type: str | None = None,
    skip: int = 0,
    limit: int = 100,
    db: Session = Depends(get_db),
):
    """List purchase registers with optional filtering (from legacy adapter if enabled)"""
    if is_legacy_source_enabled():
        try:
            data = list_purchases_legacy(skip=skip, limit=limit, estado=status_filter)
            if isinstance(data, dict) and "items" in data:
                return data["items"]
            elif isinstance(data, list):
                return data
            else:
                return [data] if data else []
        except Exception as exc:
            logger.error(f"Failed to fetch purchases from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Start sigecoom-wcf-adapter.exe or check SIGECOM_LEGACY_ADAPTER_BASE_URL.",
            )

    # Fallback to local SQLite
    query = db.query(PurchaseRegisterModel)
    if status_filter:
        query = query.filter(PurchaseRegisterModel.status == status_filter)
    if document_type:
        query = query.filter(PurchaseRegisterModel.document_type == document_type)
    registers = query.order_by(PurchaseRegisterModel.document_date.desc()).offset(skip).limit(limit).all()
    return registers


@router.get("/{register_id}", response_model=PurchaseRegisterRead)
def get_purchase_register(register_id: str, db: Session = Depends(get_db)):
    """Get a specific purchase register by ID."""
    db_register = db.query(PurchaseRegisterModel).filter(PurchaseRegisterModel.id == register_id).first()
    if not db_register:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Purchase register {register_id} not found")
    return db_register


@router.post("", response_model=PurchaseRegisterRead)
def create_purchase_register(register: PurchaseRegisterCreate, db: Session = Depends(get_db)):
    """Create a new purchase register."""
    db_register = PurchaseRegisterModel(
        id=str(uuid.uuid4()),
        document_type=register.document_type,
        series=register.series,
        number=register.number,
        document_date=register.document_date,
        supplier_ruc=register.supplier_ruc,
        supplier_name=register.supplier_name,
        currency=register.currency,
        taxable_base=register.taxable_base,
        igv=register.igv,
        non_taxable=register.non_taxable,
        total=register.total,
        retention=register.retention or 0,
        cost_center=register.cost_center,
        reference=register.reference,
        description=register.description,
        extra_data=register.extra_data,
        status="draft",
    )
    db.add(db_register)
    db.commit()
    db.refresh(db_register)
    return db_register


@router.put("/{register_id}", response_model=PurchaseRegisterRead)
def update_purchase_register(register_id: str, register: PurchaseRegisterUpdate, db: Session = Depends(get_db)):
    """Update a purchase register."""
    db_register = db.query(PurchaseRegisterModel).filter(PurchaseRegisterModel.id == register_id).first()
    if not db_register:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Purchase register {register_id} not found")

    update_data = register.dict(exclude_unset=True)
    for key, value in update_data.items():
        setattr(db_register, key, value)

    db.add(db_register)
    db.commit()
    db.refresh(db_register)
    return db_register


@router.delete("/{register_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_purchase_register(register_id: str, db: Session = Depends(get_db)):
    """Delete a purchase register (soft delete via status)."""
    db_register = db.query(PurchaseRegisterModel).filter(PurchaseRegisterModel.id == register_id).first()
    if not db_register:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Purchase register {register_id} not found")

    db_register.status = "cancelled"
    db.add(db_register)
    db.commit()
