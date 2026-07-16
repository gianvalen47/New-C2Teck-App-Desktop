from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy import or_
from sqlalchemy.orm import Session

from config import SessionLocal
from models import LocationModel
from schemas import LocationCreate, LocationRead, LocationUpdate

router = APIRouter(prefix="/locations", tags=["Locations"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[LocationRead])
def list_locations(skip: int = 0, limit: int = 100, search: str | None = None, db: Session = Depends(get_db)):
    query = db.query(LocationModel)
    if search:
        term = f"%{search.strip()}%"
        query = query.filter(
            or_(
                LocationModel.code.ilike(term),
                LocationModel.warehouse.ilike(term),
                LocationModel.aisle.ilike(term),
                LocationModel.shelf.ilike(term),
                LocationModel.row.ilike(term),
                LocationModel.level.ilike(term),
                LocationModel.description.ilike(term),
            )
        )
    return query.offset(skip).limit(limit).all()


@router.post("", response_model=LocationRead)
def create_location(location: LocationCreate, db: Session = Depends(get_db)):
    existing = db.query(LocationModel).filter(LocationModel.code == location.code).first()
    if existing:
        raise HTTPException(status_code=status.HTTP_400_BAD_REQUEST, detail="Código de ubicación ya existe")
    db_location = LocationModel(
        id=str(location.code) if location.code else None,
        code=location.code,
        warehouse=location.warehouse,
        aisle=location.aisle,
        shelf=location.shelf,
        row=location.row,
        level=location.level,
        description=location.description,
        capacity=location.capacity,
        occupancy_percent=location.occupancy_percent,
        active=location.active,
    )
    db.add(db_location)
    db.commit()
    db.refresh(db_location)
    return db_location


@router.get("/{location_id}", response_model=LocationRead)
def get_location(location_id: str, db: Session = Depends(get_db)):
    location = db.query(LocationModel).filter(LocationModel.id == location_id).first()
    if not location:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Ubicación {location_id} no encontrada")
    return location


@router.put("/{location_id}", response_model=LocationRead)
def update_location(location_id: str, location: LocationUpdate, db: Session = Depends(get_db)):
    db_location = db.query(LocationModel).filter(LocationModel.id == location_id).first()
    if not db_location:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Ubicación {location_id} no encontrada")
    for key, value in location.dict(exclude_unset=True).items():
        setattr(db_location, key, value)
    db.commit()
    db.refresh(db_location)
    return db_location


@router.delete("/{location_id}", status_code=status.HTTP_204_NO_CONTENT)
def delete_location(location_id: str, db: Session = Depends(get_db)):
    db_location = db.query(LocationModel).filter(LocationModel.id == location_id).first()
    if not db_location:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Ubicación {location_id} no encontrada")
    db.delete(db_location)
    db.commit()
    return None
