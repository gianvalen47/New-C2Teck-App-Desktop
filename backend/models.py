"""
SQLAlchemy models for SIGECOM database
"""
from datetime import datetime
from sqlalchemy import JSON, Boolean, Column, DateTime, Float, Integer, String, Text, func
from config import Base


class ClientModel(Base):
    """Cliente/Empresa model"""
    __tablename__ = "clients"
    
    id = Column(String, primary_key=True, index=True)
    name = Column(String, nullable=False, index=True)
    ruc = Column(String, nullable=True, index=True, unique=True)
    address = Column(Text, nullable=True)
    phone = Column(String, nullable=True)
    email = Column(String, nullable=True)
    active = Column(Integer, default=1)  # 1=active, 0=inactive
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class SaleModel(Base):
    """Sales/Invoices model (Factura, Boleta, Guía)"""
    __tablename__ = "sales"
    
    id = Column(String, primary_key=True, index=True)
    type = Column(String, nullable=False)  # 'factura', 'boleta', 'guia'
    series = Column(String, nullable=True)
    number = Column(Integer, nullable=True)
    date = Column(DateTime, nullable=True, server_default=func.now())
    client_id = Column(String, nullable=True, index=True)
    items = Column(JSON, nullable=True)  # List of items with code, desc, qty, price
    subtotal = Column(Float, nullable=True, default=0)
    tax = Column(Float, nullable=True, default=0)
    total = Column(Float, nullable=True, default=0)
    status = Column(String, default="draft")  # draft, issued, cancelled
    extra_data = Column(JSON, nullable=True)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class JournalEntryModel(Base):
    """Contabilidad - Asiento contable"""
    __tablename__ = "journal_entries"

    id = Column(String, primary_key=True, index=True)
    entry_number = Column(String, nullable=False, index=True)
    date = Column(DateTime, nullable=False, server_default=func.now())
    type = Column(String, nullable=False, default="Diario")
    currency = Column(String, nullable=False, default="PEN")
    exchange_rate = Column(Float, nullable=True, default=1.0)
    description = Column(Text, nullable=True)
    lines = Column(JSON, nullable=True)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class BankAccountModel(Base):
    """Banco: cuenta bancaria"""
    __tablename__ = "bank_accounts"

    id = Column(String, primary_key=True, index=True)
    bank_name = Column(String, nullable=False)
    account_number = Column(String, nullable=False, index=True)
    currency = Column(String, nullable=False, default="PEN")
    active = Column(Integer, default=1)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class BankTransactionModel(Base):
    """Movimiento bancario / ERP para conciliación"""
    __tablename__ = "bank_transactions"

    id = Column(String, primary_key=True, index=True)
    bank_account_id = Column(String, nullable=True, index=True)
    source = Column(String, nullable=False, default="bank")
    date = Column(DateTime, nullable=True, server_default=func.now())
    description = Column(Text, nullable=False)
    reference = Column(String, nullable=True)
    amount = Column(Float, nullable=False, default=0)
    direction = Column(String, nullable=False, default="cargo")
    reconciled = Column(Boolean, default=False)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class InventoryItemModel(Base):
    """Inventory/Stock model"""
    __tablename__ = "inventory"
    
    id = Column(String, primary_key=True, index=True)
    sku = Column(String, nullable=False, index=True, unique=True)
    name = Column(String, nullable=False)
    description = Column(Text, nullable=True)
    category = Column(String, nullable=True)
    stock = Column(Integer, nullable=False, default=0)
    min_stock = Column(Integer, nullable=True, default=10)
    supplier = Column(String, nullable=True)
    cost_price = Column(Float, nullable=True)
    sale_price = Column(Float, nullable=True)
    unit = Column(String, default="unidad")
    active = Column(Integer, default=1)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class LocationModel(Base):
    """Warehouse location model"""
    __tablename__ = "locations"

    id = Column(String, primary_key=True, index=True)
    code = Column(String, nullable=False, unique=True, index=True)
    warehouse = Column(String, nullable=False)
    aisle = Column(String, nullable=True)
    shelf = Column(String, nullable=True)
    row = Column(String, nullable=True)
    level = Column(String, nullable=True)
    description = Column(Text, nullable=True)
    capacity = Column(Integer, nullable=True)
    occupancy_percent = Column(Float, nullable=True)
    active = Column(Integer, default=1)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class PurchaseRegisterModel(Base):
    """Registro de Compra - Purchase register for tax purposes"""
    __tablename__ = "purchase_registers"

    id = Column(String, primary_key=True, index=True)
    document_type = Column(String, nullable=False)  # Factura, Boleta, Recibo x Honorarios, Nota Crédito
    series = Column(String, nullable=True, index=True)
    number = Column(String, nullable=True, index=True)
    document_date = Column(DateTime, nullable=False)
    receipt_date = Column(DateTime, nullable=True, server_default=func.now())
    supplier_ruc = Column(String, nullable=False, index=True)
    supplier_name = Column(String, nullable=False)
    currency = Column(String, nullable=False, default="PEN")
    taxable_base = Column(Float, nullable=False, default=0)
    igv = Column(Float, nullable=False, default=0)
    non_taxable = Column(Float, nullable=False, default=0)
    total = Column(Float, nullable=False, default=0)
    retention = Column(Float, nullable=True, default=0)  # 4ta categoría / detracción
    cost_center = Column(String, nullable=True)
    reference = Column(String, nullable=True)
    description = Column(Text, nullable=True)
    status = Column(String, default="draft")  # draft, registered, cancelled
    extra_data = Column(JSON, nullable=True)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class CajaChicaModel(Base):
    """Caja Chica - Petty cash account"""
    __tablename__ = "caja_chica"

    id = Column(String, primary_key=True, index=True)
    name = Column(String, nullable=False, index=True)
    responsible = Column(String, nullable=False)
    assigned_fund = Column(Float, nullable=False, default=0)
    currency = Column(String, nullable=False, default="PEN")
    status = Column(String, default="active")  # active, closed, archived
    location = Column(String, nullable=True)
    extra_data = Column(JSON, nullable=True)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class GastoModel(Base):
    """Gasto - Expense in petty cash"""
    __tablename__ = "gastos"

    id = Column(String, primary_key=True, index=True)
    caja_chica_id = Column(String, nullable=False, index=True)
    date = Column(DateTime, nullable=False, server_default=func.now())
    concept = Column(String, nullable=False)
    voucher_type = Column(String, nullable=True)  # Ticket, Factura, Recibo
    voucher_number = Column(String, nullable=True)
    amount = Column(Float, nullable=False, default=0)
    category = Column(String, nullable=False)  # Alimentación, Transporte, Oficina, etc.
    description = Column(Text, nullable=True)
    status = Column(String, default="pending")  # pending, submitted, reimbursed, archived
    submitted_date = Column(DateTime, nullable=True)
    reimbursed_date = Column(DateTime, nullable=True)
    extra_data = Column(JSON, nullable=True)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class GuiaRemisionModel(Base):
    """Guía de Remisión - Delivery note header"""
    __tablename__ = "guias_remision"

    id = Column(Integer, primary_key=True, index=True, autoincrement=True)
    id_locacion = Column(Integer, nullable=False, index=True)        # Oficina/Almacén
    fec_doc = Column(DateTime, nullable=False)                       # Fecha documento
    id_serie_doc = Column(Integer, nullable=True)                    # Serie del documento
    num_doc = Column(Integer, nullable=False)                        # Número correlativo
    id_cliente = Column(Integer, nullable=False, index=True)         # Cliente
    id_loc_cli = Column(Integer, nullable=True)                      # Locación del cliente
    id_fiscal = Column(Integer, nullable=True)                       # Dirección fiscal del cliente
    cod_mot = Column(String, nullable=False)                         # Motivo (1=Venta, 2=Transf.gratuita, ...)
    num_job = Column(String, nullable=True)                          # N° OT / Job
    pto_partida = Column(Text, nullable=True)                        # Punto de partida
    pto_llegada = Column(Text, nullable=True)                        # Punto de llegada / Loc. cliente
    cod_mon = Column(String, nullable=False, default="NS")           # Moneda (NS=Soles, US=Dólares)
    igv = Column(Float, nullable=False, default=18.0)               # % IGV
    tip_cambio = Column(Float, nullable=True, default=1.0)          # Tipo de cambio
    tot_flete = Column(Float, nullable=False, default=0.0)          # Flete
    tot_embarque = Column(Float, nullable=False, default=0.0)       # Embarque
    tot_bruto = Column(Float, nullable=False, default=0.0)          # Subtotal bruto
    tot_dscto = Column(Float, nullable=False, default=0.0)          # Total descuento
    tot_venta = Column(Float, nullable=False, default=0.0)          # Total venta
    tot_igv = Column(Float, nullable=False, default=0.0)            # Total IGV
    tot_neto = Column(Float, nullable=False, default=0.0)           # Total neto
    num_orden = Column(String, nullable=True)                        # N° Orden de compra cliente
    id_cotizacion = Column(Integer, nullable=True)                   # Cotización vinculada
    observacion = Column(Text, nullable=True)                        # Observación
    # Campos para guía electrónica SUNAT
    peso_bruto = Column(Float, nullable=False, default=0.0)         # Peso total
    cod_uni_med_peso = Column(String, nullable=False, default="KGM") # Unidad de medida del peso
    numero_bultos = Column(Integer, nullable=False, default=1)      # Cant. bultos/palets
    fec_traslado = Column(DateTime, nullable=True)                   # Fecha inicio traslado
    cod_modo = Column(String, nullable=False, default="02")         # Modo traslado (01=Público, 02=Privado)
    estado = Column(String, nullable=False, default="GENERADO")     # GENERADO, APROBADO, CREDITOS, ANULADO
    tip_mov = Column(String, nullable=True)                         # Tipo de movimiento
    cod_usu = Column(String, nullable=True)                         # Usuario que registró
    nom_pc = Column(String, nullable=True)                          # Nombre del equipo
    dir_ip = Column(String, nullable=True)                          # Dirección IP
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class GuiaRemisionDetModel(Base):
    """Guía de Remisión - Delivery note detail lines"""
    __tablename__ = "guias_remision_det"

    id = Column(Integer, primary_key=True, index=True, autoincrement=True)
    id_guia = Column(Integer, nullable=False, index=True)            # FK -> GuiaRemision
    item = Column(Integer, nullable=False, default=1)               # N° ítem
    cod_mer = Column(String, nullable=False, index=True)            # Código mercadería
    des_mer = Column(String, nullable=True)                         # Descripción
    cod_uni_med = Column(String, nullable=True)                     # Unidad de medida
    can_mer = Column(Float, nullable=False, default=0)              # Cantidad
    pre_mer = Column(Float, nullable=False, default=0.0)            # Precio unitario
    dsc_mer = Column(Float, nullable=False, default=0.0)            # Descuento unitario
    total_fila = Column(Float, nullable=False, default=0.0)         # Total línea
    regalo = Column(Boolean, nullable=False, default=False)         # Es regalo / cortesía
    no_core = Column(Boolean, nullable=False, default=False)        # Sin core
    cod_usu = Column(String, nullable=True)
    nom_pc = Column(String, nullable=True)
    dir_ip = Column(String, nullable=True)
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class TransportistaGuiaModel(Base):
    """Transportista vinculado a la guía de remisión"""
    __tablename__ = "transportistas_guia"

    id = Column(Integer, primary_key=True, index=True, autoincrement=True)
    id_guia = Column(Integer, nullable=False, index=True)           # FK -> GuiaRemision
    empresa = Column(String, nullable=True)                         # Empresa transportista
    direccion = Column(String, nullable=True)                       # Dirección empresa
    ruc = Column(String, nullable=True)                             # RUC transportista
    vehiculo = Column(String, nullable=True)                        # Vehículo
    placa = Column(String, nullable=True)                           # Placa
    chofer = Column(String, nullable=True)                          # Nombre del chofer
    licencia = Column(String, nullable=True)                        # Licencia conducir
    cod_doc_chofer = Column(String, nullable=True)                  # Tipo doc. chofer (DNI, etc.)
    num_doc_chofer = Column(String, nullable=True)                  # N° documento chofer
    con_ins = Column(String, nullable=True)                         # Constancia de inscripción
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())


class UserModel(Base):
    """User/Login model"""
    __tablename__ = "users"
    
    id = Column(String, primary_key=True, index=True)
    username = Column(String, nullable=False, index=True, unique=True)
    email = Column(String, nullable=True, unique=True)
    password_hash = Column(String, nullable=False)
    full_name = Column(String, nullable=True)
    active = Column(Integer, default=1)
    role = Column(String, default="user")  # 'admin', 'user', 'viewer'
    created_at = Column(DateTime, server_default=func.now())
    updated_at = Column(DateTime, onupdate=func.now())
