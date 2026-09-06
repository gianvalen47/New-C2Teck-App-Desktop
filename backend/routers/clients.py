"""
API routers for clients
Consumes from legacy SIGECOM adapter when enabled, otherwise uses local SQLite.
"""
import logging
import uuid
from datetime import datetime

from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session

from config import SessionLocal
from models import ClientModel
from schemas import ClientCreate, ClientRead, ClientUpdate, ClientsListResponse
from legacy_adapter import (
    is_legacy_source_enabled,
    list_clients_legacy,
    get_client_legacy,
)

logger = logging.getLogger(__name__)

router = APIRouter(prefix="/clients", tags=["Clients"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=ClientsListResponse)
def list_clients(skip: int = 0, limit: int = 0, db: Session = Depends(get_db)):
    """List clients.

    Returns a dictionary: { items: [...], total: N } so the frontend can show
    the server-side total and loaded counts (matching SIGECOM desktop behaviour).
    When legacy source is enabled this delegates to the legacy adapter which
    already returns `{'items': ..., 'total': ...}`. When using the local DB the
    endpoint will compute the total and return the same shape.
    """
    if is_legacy_source_enabled():
        try:
            data = list_clients_legacy(skip=skip, limit=limit)
            # data is expected to be a dict with 'items' and 'total'
            if isinstance(data, dict) and "items" in data:
                return data
            elif isinstance(data, list):
                return {"items": data, "total": len(data)}
            else:
                raise HTTPException(
                    status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                    detail="Legacy adapter returned unexpected format"
                )
        except Exception as e:
            logger.error(f"Failed to fetch clients from legacy adapter: {e}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(e).__name__}. Start sigecoom-wcf-adapter.exe."
            )

    # Fallback to local SQLite - return same shape with total count
    total = db.query(ClientModel).count()
    clients = db.query(ClientModel).offset(skip)
    if limit and limit > 0:
        clients = clients.limit(limit)
    clients = clients.all()
            return {"items": clients, "total": total}


@router.get("/{client_id}", response_model=ClientRead)
def get_client(client_id: str, db: Session = Depends(get_db)):
    """Get a specific client (from legacy adapter if enabled)"""
    if is_legacy_source_enabled():
        try:
            data = get_client_legacy(client_id)
            return data
        except Exception as e:
            logger.error(f"Failed to fetch client {client_id} from legacy adapter: {e}")
            raise HTTPException(
                status_code=status.HTTP_503_SERVICE_UNAVAILABLE,
                detail=f"Legacy adapter unavailable: {type(e).__name__}. Start sigecoom-wcf-adapter.exe."
            )

    # Fallback to local SQLite
    client = db.query(ClientModel).filter(ClientModel.id == client_id).first()
    if not client:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND,
            detail=f"Client {client_id} not found"
        )
    return client


@router.post("", response_model=ClientRead)
def create_client(client: ClientCreate, db: Session = Depends(get_db)):
    """Create a new client"""
    # Check if RUC already exists
    if client.ruc:
        existing = db.query(ClientModel).filter(ClientModel.ruc == client.ruc).first()
        if existing:
            raise HTTPException(
                status_code=status.HTTP_400_BAD_REQUEST,
                detail=f"Client with RUC {client.ruc} already exists"
            )
    
    db_client = ClientModel(
        id=str(uuid.uuid4()),
        name=client.name,
        ruc=client.ruc,
        address=client.address,
        phone=client.phone,
        email=client.email
    )
    db.add(db_client)
    db.commit()
    db.refresh(db_client)
    return db_client


@router.put("/{client_id}", response_model=ClientRead)
def update_client(client_id: str, client: ClientUpdate, db: Session = Depends(get_db)):
    """Update a client"""
    db_client = db.query(ClientModel).filter(ClientModel.id == client_id).first()
    if not db_client:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND,
            detail=f"Client {client_id} not found"
        )
    
    update_data = client.dict(exclude_unset=True)
    for key, value in update_data.items():
        setattr(db_client, key, value)
    
    db.add(db_client)
    db.commit()
    db.refresh(db_client)
    return db_client


@router.delete("/{client_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_client(client_id: str, db: Session = Depends(get_db)):
    """Delete a client (soft delete - mark as inactive)"""
    db_client = db.query(ClientModel).filter(ClientModel.id == client_id).first()
    if not db_client:
        raise HTTPException(
            status_code=status.HTTP_404_NOT_FOUND,
            detail=f"Client {client_id} not found"
        )
    
    db_client.active = 0
    db.add(db_client)
    db.commit()
