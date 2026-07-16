"""
Pydantic schemas for request/response validation
"""
from datetime import datetime
from typing import List, Optional
from pydantic import BaseModel, Field


# ============================================================================
# CLIENT SCHEMAS
# ============================================================================

class ItemSchema(BaseModel):
    """Item in a sale"""
    code: Optional[str] = None
    description: str
    unit: str = "unidad"
    quantity: float
    price: float
    total: Optional[float] = None

    class Config:
        from_attributes = True


class ClientBase(BaseModel):
    """Base client schema"""
    name: str = Field(..., min_length=1)
    ruc: Optional[str] = None
    address: Optional[str] = None
    phone: Optional[str] = None
    email: Optional[str] = None


class ClientCreate(ClientBase):
    """Create client"""
    pass


class ClientUpdate(BaseModel):
    """Update client"""
    name: Optional[str] = None
    address: Optional[str] = None
    phone: Optional[str] = None
    email: Optional[str] = None
    active: Optional[int] = None


class ClientRead(ClientBase):
    """Read client"""
    id: str
    active: int
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


# ============================================================================
# SALE/INVOICE SCHEMAS
# ============================================================================

class SaleCreate(BaseModel):
    """Create sale/invoice"""
    type: str  # 'factura', 'boleta', 'guia'
    series: Optional[str] = None
    number: Optional[int] = None
    date: Optional[datetime] = None
    client_id: Optional[str] = None
    items: List[ItemSchema] = []
    subtotal: Optional[float] = 0
    tax: Optional[float] = 0
    total: Optional[float] = 0
    extra_data: Optional[dict] = None


class SaleUpdate(BaseModel):
    """Update sale"""
    client_id: Optional[str] = None
    date: Optional[datetime] = None
    items: Optional[List[ItemSchema]] = None
    subtotal: Optional[float] = None
    tax: Optional[float] = None
    total: Optional[float] = None
    status: Optional[str] = None
    extra_data: Optional[dict] = None


class SaleRead(BaseModel):
    """Read sale"""
    id: str
    type: str
    series: Optional[str]
    number: Optional[int]
    date: datetime
    client_id: Optional[str]
    items: Optional[List[ItemSchema]]
    subtotal: float
    tax: float
    total: float
    status: str
    extra_data: Optional[dict] = None
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


class JournalLineSchema(BaseModel):
    """Line item for journal entry"""
    account: str
    description: Optional[str] = None
    reference: Optional[str] = None
    debit: float = 0
    credit: float = 0
    cost_center: Optional[str] = None

    class Config:
        from_attributes = True


class JournalEntryCreate(BaseModel):
    """Create journal entry"""
    entry_number: str
    date: Optional[datetime] = None
    type: str = "Diario"
    currency: str = "PEN"
    exchange_rate: Optional[float] = 1.0
    description: Optional[str] = None
    lines: List[JournalLineSchema] = []


class JournalEntryRead(BaseModel):
    """Read journal entry"""
    id: str
    entry_number: str
    date: datetime
    type: str
    currency: str
    exchange_rate: Optional[float] = None
    description: Optional[str] = None
    lines: List[JournalLineSchema]
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


class BankAccountBase(BaseModel):
    """Bank account base schema"""
    bank_name: str
    account_number: str
    currency: str = "PEN"


class BankAccountCreate(BankAccountBase):
    """Create bank account"""
    pass


class BankAccountRead(BankAccountBase):
    """Read bank account"""
    id: str
    active: int
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


class BankTransactionCreate(BaseModel):
    """Create bank or ERP transaction"""
    bank_account_id: Optional[str] = None
    source: str = "bank"
    date: Optional[datetime] = None
    description: str
    reference: Optional[str] = None
    amount: float
    direction: str
    reconciled: Optional[bool] = False


class BankTransactionUpdate(BaseModel):
    """Update bank transaction"""
    reconciled: Optional[bool] = None


class BankTransactionRead(BaseModel):
    """Read bank transaction"""
    id: str
    bank_account_id: Optional[str] = None
    source: str
    date: datetime
    description: str
    reference: Optional[str] = None
    amount: float
    direction: str
    reconciled: bool
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


# ============================================================================
# INVENTORY SCHEMAS
# ============================================================================

class InventoryItemBase(BaseModel):
    """Base inventory item"""
    sku: str = Field(..., min_length=1)
    name: str = Field(..., min_length=1)
    description: Optional[str] = None
    category: Optional[str] = None
    stock: int = 0
    min_stock: Optional[int] = 10
    supplier: Optional[str] = None
    cost_price: Optional[float] = None
    sale_price: Optional[float] = None
    unit: str = "unidad"


class InventoryItemCreate(InventoryItemBase):
    """Create inventory item"""
    pass


class InventoryItemUpdate(BaseModel):
    """Update inventory item"""
    name: Optional[str] = None
    description: Optional[str] = None
    stock: Optional[int] = None
    min_stock: Optional[int] = None
    supplier: Optional[str] = None
    cost_price: Optional[float] = None
    sale_price: Optional[float] = None
    active: Optional[int] = None


class InventoryItemRead(InventoryItemBase):
    """Read inventory item"""
    id: str
    active: int
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


# ============================================================================
# LOCATION SCHEMAS
# ============================================================================

class LocationBase(BaseModel):
    """Base warehouse location schema"""
    code: str = Field(..., min_length=1)
    warehouse: str = Field(..., min_length=1)
    aisle: Optional[str] = None
    shelf: Optional[str] = None
    row: Optional[str] = None
    level: Optional[str] = None
    description: Optional[str] = None
    capacity: Optional[int] = None
    occupancy_percent: Optional[float] = None
    active: int = 1


class LocationCreate(LocationBase):
    """Create location"""
    pass


class LocationUpdate(BaseModel):
    """Update location"""
    code: Optional[str] = None
    warehouse: Optional[str] = None
    aisle: Optional[str] = None
    shelf: Optional[str] = None
    row: Optional[str] = None
    level: Optional[str] = None
    description: Optional[str] = None
    capacity: Optional[int] = None
    occupancy_percent: Optional[float] = None
    active: Optional[int] = None


class LocationRead(LocationBase):
    """Read location"""
    id: str
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


# ============================================================================
# USER SCHEMAS
# ============================================================================

class UserBase(BaseModel):
    """Base user"""
    username: str = Field(..., min_length=3)
    email: Optional[str] = None
    full_name: Optional[str] = None


class UserCreate(UserBase):
    """Create user"""
    password: str = Field(..., min_length=6)


class UserUpdate(BaseModel):
    """Update user"""
    email: Optional[str] = None
    full_name: Optional[str] = None
    active: Optional[int] = None
    role: Optional[str] = None


class UserRead(UserBase):
    """Read user"""
    id: str
    active: int
    role: str
    created_at: datetime

    class Config:
        from_attributes = True


# ============================================================================
# PURCHASE REGISTER SCHEMAS
# ============================================================================

class PurchaseRegisterBase(BaseModel):
    """Base purchase register"""
    document_type: str
    series: Optional[str] = None
    number: Optional[str] = None
    document_date: datetime
    supplier_ruc: str = Field(..., min_length=1)
    supplier_name: str = Field(..., min_length=1)
    currency: str = "PEN"
    taxable_base: float = 0
    igv: float = 0
    non_taxable: float = 0
    total: float
    retention: Optional[float] = 0
    cost_center: Optional[str] = None
    reference: Optional[str] = None
    description: Optional[str] = None


class PurchaseRegisterCreate(PurchaseRegisterBase):
    """Create purchase register"""
    extra_data: Optional[dict] = None


class PurchaseRegisterUpdate(BaseModel):
    """Update purchase register"""
    document_type: Optional[str] = None
    supplier_name: Optional[str] = None
    currency: Optional[str] = None
    taxable_base: Optional[float] = None
    igv: Optional[float] = None
    non_taxable: Optional[float] = None
    total: Optional[float] = None
    retention: Optional[float] = None
    cost_center: Optional[str] = None
    reference: Optional[str] = None
    description: Optional[str] = None
    status: Optional[str] = None
    extra_data: Optional[dict] = None


class PurchaseRegisterRead(PurchaseRegisterBase):
    """Read purchase register"""
    id: str
    receipt_date: datetime
    status: str
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


# ============================================================================
# CAJA CHICA SCHEMAS
# ============================================================================

class CajaChicaBase(BaseModel):
    """Base Caja Chica schema"""
    name: str = Field(..., min_length=1)
    responsible: str = Field(..., min_length=1)
    assigned_fund: float
    currency: str = "PEN"
    location: Optional[str] = None


class CajaChicaCreate(CajaChicaBase):
    """Create Caja Chica"""
    pass


class CajaChicaUpdate(BaseModel):
    """Update Caja Chica"""
    name: Optional[str] = None
    responsible: Optional[str] = None
    assigned_fund: Optional[float] = None
    status: Optional[str] = None
    location: Optional[str] = None


class CajaChicaRead(CajaChicaBase):
    """Read Caja Chica"""
    id: str
    status: str
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


class GastoBase(BaseModel):
    """Base expense schema"""
    date: datetime
    concept: str = Field(..., min_length=1)
    voucher_type: Optional[str] = None
    voucher_number: Optional[str] = None
    amount: float
    category: str = Field(..., min_length=1)
    description: Optional[str] = None


class GastoCreate(BaseModel):
    """Create expense"""
    date: Optional[datetime] = None
    concept: str = Field(..., min_length=1)
    voucher_type: Optional[str] = None
    voucher_number: Optional[str] = None
    amount: float
    category: str = Field(..., min_length=1)
    description: Optional[str] = None


class GastoUpdate(BaseModel):
    """Update expense"""
    concept: Optional[str] = None
    amount: Optional[float] = None
    category: Optional[str] = None
    description: Optional[str] = None
    status: Optional[str] = None
    submitted_date: Optional[datetime] = None
    reimbursed_date: Optional[datetime] = None


class GastoRead(GastoBase):
    """Read expense"""
    id: str
    caja_chica_id: str
    status: str
    submitted_date: Optional[datetime]
    reimbursed_date: Optional[datetime]
    created_at: datetime
    updated_at: Optional[datetime]

    class Config:
        from_attributes = True


# ============================================================================
# HEALTH CHECK
# ============================================================================

class HealthCheck(BaseModel):
    """Health check response"""
    status: str
    version: str
    database: str
