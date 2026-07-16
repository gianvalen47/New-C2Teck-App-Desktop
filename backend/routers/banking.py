"""
API routers for bank accounts and bank reconciliation transactions
"""
from fastapi import APIRouter, Depends, HTTPException, status
from sqlalchemy.orm import Session
import uuid

from config import SessionLocal
from models import BankAccountModel, BankTransactionModel
from schemas import (
    BankAccountCreate,
    BankAccountRead,
    BankTransactionCreate,
    BankTransactionRead,
    BankTransactionUpdate,
)

router = APIRouter(prefix="/banking", tags=["Banking"])


def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("", response_model=list[BankAccountRead])
def list_bank_accounts(skip: int = 0, limit: int = 100, db: Session = Depends(get_db)):
    accounts = db.query(BankAccountModel).offset(skip).limit(limit).all()
    return accounts


@router.post("", response_model=BankAccountRead)
def create_bank_account(account: BankAccountCreate, db: Session = Depends(get_db)):
    db_account = BankAccountModel(
        id=str(uuid.uuid4()),
        bank_name=account.bank_name,
        account_number=account.account_number,
        currency=account.currency,
    )
    db.add(db_account)
    db.commit()
    db.refresh(db_account)
    return db_account


@router.get("/transactions", response_model=list[BankTransactionRead])
def list_bank_transactions(
    source: str | None = None,
    bank_account_id: str | None = None,
    skip: int = 0,
    limit: int = 100,
    db: Session = Depends(get_db),
):
    query = db.query(BankTransactionModel)
    if source:
        query = query.filter(BankTransactionModel.source == source)
    if bank_account_id:
        query = query.filter(BankTransactionModel.bank_account_id == bank_account_id)
    transactions = query.order_by(BankTransactionModel.date.desc()).offset(skip).limit(limit).all()
    return transactions


@router.post("/transactions", response_model=BankTransactionRead)
def create_bank_transaction(transaction: BankTransactionCreate, db: Session = Depends(get_db)):
    db_transaction = BankTransactionModel(
        id=str(uuid.uuid4()),
        bank_account_id=transaction.bank_account_id,
        source=transaction.source,
        date=transaction.date,
        description=transaction.description,
        reference=transaction.reference,
        amount=transaction.amount,
        direction=transaction.direction,
        reconciled=transaction.reconciled or False,
    )
    db.add(db_transaction)
    db.commit()
    db.refresh(db_transaction)
    return db_transaction


@router.put("/transactions/{transaction_id}", response_model=BankTransactionRead)
def update_bank_transaction(transaction_id: str, transaction: BankTransactionUpdate, db: Session = Depends(get_db)):
    db_transaction = db.query(BankTransactionModel).filter(BankTransactionModel.id == transaction_id).first()
    if not db_transaction:
        raise HTTPException(status_code=status.HTTP_404_NOT_FOUND, detail=f"Transaction {transaction_id} not found")

    update_data = transaction.dict(exclude_unset=True)
    for key, value in update_data.items():
        setattr(db_transaction, key, value)

    db.add(db_transaction)
    db.commit()
    db.refresh(db_transaction)
    return db_transaction
