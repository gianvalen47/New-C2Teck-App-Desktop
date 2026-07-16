"""
API routers for journal entries / accounting
"""
from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session
import uuid

from config import SessionLocal
from models import JournalEntryModel
from schemas import JournalEntryCreate, JournalEntryRead

router = APIRouter(prefix="/journals", tags=["Journals"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[JournalEntryRead])
def list_journal_entries(skip: int = 0, limit: int = 100, db: Session = Depends(get_db)):
    """List journal entries"""
    entries = db.query(JournalEntryModel).offset(skip).limit(limit).order_by(JournalEntryModel.date.desc()).all()
    return entries


@router.get("/{entry_id}", response_model=JournalEntryRead)
def get_journal_entry(entry_id: str, db: Session = Depends(get_db)):
    """Get a journal entry by ID"""
    entry = db.query(JournalEntryModel).filter(JournalEntryModel.id == entry_id).first()
    if not entry:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Journal entry {entry_id} not found")
    return entry


@router.post("", response_model=JournalEntryRead)
def create_journal_entry(entry: JournalEntryCreate, db: Session = Depends(get_db)):
    """Create a new journal entry"""
    db_entry = JournalEntryModel(
        id=str(uuid.uuid4()),
        entry_number=entry.entry_number,
        date=entry.date,
        type=entry.type,
        currency=entry.currency,
        exchange_rate=entry.exchange_rate,
        description=entry.description,
        lines=[line.dict() for line in entry.lines],
    )
    db.add(db_entry)
    db.commit()
    db.refresh(db_entry)
    return db_entry
