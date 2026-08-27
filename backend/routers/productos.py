"""
API routers for productos (inventory items/merchandise)

Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
Extracted from: SIGECOM\SIGECOM\Interfaces\Tablas\Almacen\Productos\frmProducto.vb
"""
import logging
import uuid

from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session

from config import SessionLocal
from models import InventoryItemModel  # Reusing existing model for now
from schemas import InventoryItemCreate, InventoryItemRead, InventoryItemUpdate
from legacy_adapter import (
    is_legacy_source_enabled,
    list_inventory_legacy,
    get_inventory_item_legacy,
)

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/productos", tags=["Productos"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[InventoryItemRead])
def list_productos(
    skip: int = 0,
    limit: int = 100,
    search: str | None = None,
    category: str | None = None,
    active: bool | None = None,
    db: Session = Depends(get_db),
):
    """
    List all productos (from legacy adapter if enabled)

    Equivalent to: frmProducto.ListarProductos()
    Filters: search (CodProd, DesProd), category (CodLinea), active (Estado)
    """
    if is_legacy_source_enabled():
        try:
            data = list_inventory_legacy(
                skip=skip,
                limit=limit,
                category=category,
                active=active,
            )
            if isinstance(data, dict) and "items" in data:
                items = data["items"]
            elif isinstance(data, list):
                items = data
            else:
                items = [data] if data else []

            # Apply search filter if provided
            if search:
                search_lower = search.lower()
                items = [
                    item for item in items
                    if (search_lower in str(item.get("sku", "")).lower() or
                        search_lower in str(item.get("name", "")).lower() or
                        search_lower in str(item.get("category", "")).lower())
                ]

            return items
        except Exception as exc:
            logger.error(f"Failed to fetch productos from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Start sigecoom-wcf-adapter.exe or check SIGECOM_LEGACY_ADAPTER_BASE_URL.",
            )

    # Fallback to local SQLite
    query = db.query(InventoryItemModel)
    if search:
        search_term = f"%{search}%"
        query = query.filter(
            InventoryItemModel.sku.ilike(search_term) |
            InventoryItemModel.name.ilike(search_term) |
            InventoryItemModel.category.ilike(search_term)
        )
    if category:
        query = query.filter(InventoryItemModel.category == category)
    if active is not None:
        query = query.filter(InventoryItemModel.active == int(active))

    items = query.offset(skip).limit(limit).all()
    return items


@router.get("/{producto_id}", response_model=InventoryItemRead)
def get_producto(producto_id: str, db: Session = Depends(get_db)):
    """
    Get a specific producto by ID

    Equivalent to: frmProducto.ObtenerRegistro(IdProducto)
    """
    if is_legacy_source_enabled():
        try:
            return get_inventory_item_legacy(producto_id)
        except Exception as exc:
            logger.error(f"Failed to fetch producto {producto_id} from legacy adapter: {exc}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"SIGECOM legacy adapter unavailable: {type(exc).__name__}. "
                       f"Start sigecoom-wcf-adapter.exe or check SIGECOM_LEGACY_ADAPTER_BASE_URL.",
            )

    # Fallback to local SQLite
    item = db.query(InventoryItemModel).filter(InventoryItemModel.id == producto_id).first()
    if not item:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND,
            detail=f"Producto {producto_id} not found"
        )
    return item


@router.post("", response_model=InventoryItemRead)
def create_producto(producto: InventoryItemCreate, db: Session = Depends(get_db)):
    """
    Create a new producto (local SQLite only, not in legacy mode)

    Equivalent to: frmProducto.Guardar() with insert mode
    """
    if is_legacy_source_enabled():
        raise HTTPException(
            status_code=status.HTTP_403_FORBIDDEN,
            detail="Cannot create productos when using legacy SIGECOM adapter. "
                   "Use legacy system directly."
        )

    # Create in local SQLite
    db_item = InventoryItemModel(
        id=str(uuid.uuid4()),
        sku=producto.sku,
        name=producto.name,
        description=producto.description,
        category=producto.category,
        stock=producto.stock or 0,
        min_stock=producto.min_stock,
        supplier=producto.supplier,
        cost_price=producto.cost_price,
        sale_price=producto.sale_price,
        unit=producto.unit or "unidad",
        active=producto.active or 1,
    )
    db.add(db_item)
    db.commit()
    db.refresh(db_item)
    return db_item


@router.put("/{producto_id}", response_model=InventoryItemRead)
def update_producto(producto_id: str, producto: InventoryItemUpdate, db: Session = Depends(get_db)):
    """
    Update a producto (local SQLite only, not in legacy mode)

    Equivalent to: frmProducto.Guardar() with update mode
    """
    if is_legacy_source_enabled():
        raise HTTPException(
            status_code=status.HTTP_403_FORBIDDEN,
            detail="Cannot update productos when using legacy SIGECOM adapter. "
                   "Use legacy system directly."
        )

    db_item = db.query(InventoryItemModel).filter(InventoryItemModel.id == producto_id).first()
    if not db_item:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND,
            detail=f"Producto {producto_id} not found"
        )

    update_data = producto.dict(exclude_unset=True)
    for key, value in update_data.items():
        setattr(db_item, key, value)

    db.add(db_item)
    db.commit()
    db.refresh(db_item)
    return db_item


@router.delete("/{producto_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_producto(producto_id: str, db: Session = Depends(get_db)):
    """
    Delete a producto (soft delete - mark as inactive)

    Equivalent to: frmProducto.Guardar() with delete mode (Estado = 0)
    """
    if is_legacy_source_enabled():
        raise HTTPException(
            status_code=status.HTTP_403_FORBIDDEN,
            detail="Cannot delete productos when using legacy SIGECOM adapter. "
                   "Use legacy system directly."
        )

    db_item = db.query(InventoryItemModel).filter(InventoryItemModel.id == producto_id).first()
    if not db_item:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND,
            detail=f"Producto {producto_id} not found"
        )

    db_item.active = 0
    db.add(db_item)
    db.commit()
