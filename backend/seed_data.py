"""
Script de prueba para cargar datos iniciales en la BD de SIGECOM
"""
import sys
from pathlib import Path

BACKEND_DIR = Path(__file__).resolve().parent
sys.path.insert(0, str(BACKEND_DIR))

from config import SessionLocal, Base, engine
from models import ClientModel, SaleModel, InventoryItemModel, GuiaRemisionModel, GuiaRemisionDetModel
import uuid
from datetime import datetime, timedelta
import json

# Create tables
Base.metadata.create_all(bind=engine)
db = SessionLocal()

try:
    # ====================================================================
    # CREATE TEST CLIENTS
    # ====================================================================
    print("🔄 Creando clientes de prueba...")
    
    clients_data = [
        {
            "name": "C2teck SAC",
            "ruc": "20123456789",
            "address": "Av. Principal 123, Lima",
            "phone": "555-0001",
            "email": "info@c2teck.com"
        },
        {
            "name": "Equimap Perú",
            "ruc": "20987654321",
            "address": "Calle Secundaria 456, Lima",
            "phone": "555-0002",
            "email": "ventas@equimap.pe"
        },
        {
            "name": "Soluciones Empresariales",
            "ruc": "20555666777",
            "address": "Av. Tercera 789, Lima",
            "phone": "555-0003",
            "email": "contacto@soluciones.com"
        },
        {
            "id": "200",
            "name": "CARLOS RIOS",
            "ruc": "10412345678",
            "address": "Av. Lima 450, Lima",
            "phone": "999-555-123",
            "email": "carlos.rios@example.com"
        },
    ]
    
    for client_data in clients_data:
        existing = db.query(ClientModel).filter(
            ClientModel.ruc == client_data["ruc"]
        ).first()
        
        if not existing:
            client = ClientModel(
                id=str(uuid.uuid4()),
                **client_data
            )
            db.add(client)
            print(f"  ✅ {client_data['name']}")
    
    db.commit()
    
    # ====================================================================
    # CREATE TEST INVENTORY
    # ====================================================================
    print("\n🔄 Creando artículos de inventario...")
    
    inventory_data = [
        {
            "sku": "PROD-001",
            "name": "Licencia Software Basic",
            "description": "Licencia anual de software básico",
            "category": "Software",
            "stock": 50,
            "min_stock": 10,
            "supplier": "C2teck",
            "cost_price": 100.00,
            "sale_price": 200.00,
            "unit": "licencia"
        },
        {
            "sku": "PROD-002",
            "name": "Licencia Software Premium",
            "description": "Licencia anual de software premium con soporte",
            "category": "Software",
            "stock": 30,
            "min_stock": 5,
            "supplier": "C2teck",
            "cost_price": 500.00,
            "sale_price": 1000.00,
            "unit": "licencia"
        },
        {
            "sku": "EQUIP-001",
            "name": "GPS Tracker Modelo X1",
            "description": "GPS de seguimiento en tiempo real",
            "category": "Equipos",
            "stock": 15,
            "min_stock": 5,
            "supplier": "Equimap",
            "cost_price": 250.00,
            "sale_price": 500.00,
            "unit": "unidad"
        },
        {
            "sku": "SVC-001",
            "name": "Servicio de Instalación",
            "description": "Servicio de instalación y configuración",
            "category": "Servicios",
            "stock": 999,
            "min_stock": 1,
            "supplier": "Interno",
            "cost_price": 50.00,
            "sale_price": 150.00,
            "unit": "servicio"
        },
    ]
    
    for item_data in inventory_data:
        existing = db.query(InventoryItemModel).filter(
            InventoryItemModel.sku == item_data["sku"]
        ).first()
        
        if not existing:
            item = InventoryItemModel(
                id=str(uuid.uuid4()),
                **item_data
            )
            db.add(item)
            print(f"  ✅ {item_data['name']}")
    
    db.commit()
    
    # ====================================================================
    # CREATE TEST SALES
    # ====================================================================
    print("\n🔄 Creando ventas de prueba...")
    
    # Get first client and inventory items
    client = db.query(ClientModel).first()
    items = db.query(InventoryItemModel).all()
    
    if client and items:
        sale = SaleModel(
            id=str(uuid.uuid4()),
            type="factura",
            series="F001",
            number=1,
            date=datetime.now(),
            client_id=client.id,
            items=[
                {
                    "code": items[0].sku,
                    "description": items[0].name,
                    "unit": items[0].unit,
                    "quantity": 2,
                    "price": items[0].sale_price,
                    "total": 2 * items[0].sale_price
                },
                {
                    "code": items[2].sku,
                    "description": items[2].name,
                    "unit": items[2].unit,
                    "quantity": 1,
                    "price": items[2].sale_price,
                    "total": items[2].sale_price
                }
            ],
            subtotal=2 * items[0].sale_price + items[2].sale_price,
            tax=0,
            total=2 * items[0].sale_price + items[2].sale_price,
            status="issued"
        )
        db.add(sale)
        db.commit()
        print(f"  ✅ Factura F001-1 para {client.name}")

    # ====================================================================
    # CREATE TEST GUIA REMISION
    # ====================================================================
    print("\n🔄 Creando guías de remisión de prueba...")
    cliente_carlos = db.query(ClientModel).filter(ClientModel.id == "200").first()
    existing_guia = db.query(GuiaRemisionModel).filter(
        GuiaRemisionModel.id_locacion == 1,
        GuiaRemisionModel.id_serie_doc == 1,
        GuiaRemisionModel.num_doc == 6,
    ).first()
    if cliente_carlos and not existing_guia:
        guia = GuiaRemisionModel(
            id_locacion=1,
            fec_doc=datetime(2026, 8, 3),
            id_serie_doc=1,
            num_doc=6,
            id_cliente=200,
            id_loc_cli=None,
            id_fiscal=None,
            cod_mot="1",
            num_job="",
            pto_partida="CAL. ANTONIO ULLOA NRO. 2182 URB. EL FLORES",
            pto_llegada="OFICINA PRINCIPAL",
            cod_mon="US",
            igv=18.0,
            tip_cambio=3.4,
            tot_flete=0.0,
            tot_embarque=0.0,
            tot_bruto=100.0,
            tot_dscto=0.0,
            tot_venta=100.0,
            tot_igv=18.0,
            tot_neto=118.0,
            num_orden="OC-1234",
            id_cotizacion=123,
            observacion="Guía de remisión creada para CARLOS RIOS",
            peso_bruto=5.0,
            cod_uni_med_peso="KGM",
            numero_bultos=1,
            fec_traslado=datetime(2026, 8, 3),
            cod_modo="02",
            estado="GENERADO",
        )
        db.add(guia)
        db.commit()
        db.refresh(guia)

        detalle = GuiaRemisionDetModel(
            id_guia=guia.id,
            item=1,
            cod_mer="PROD-001",
            des_mer="Servicio de instalación",
            cod_uni_med="UN",
            can_mer=1,
            pre_mer=100.0,
            dsc_mer=0.0,
            total_fila=100.0,
        )
        db.add(detalle)
        db.commit()
        print(f"  ✅ Guía de remisión N° 6 para {cliente_carlos.name}")
    
    # ====================================================================
    # SUMMARY
    # ====================================================================
    print("\n✅ Datos de prueba cargados exitosamente!")
    
    client_count = db.query(ClientModel).count()
    sale_count = db.query(SaleModel).count()
    inventory_count = db.query(InventoryItemModel).count()
    
    print(f"\n📊 Resumen:")
    print(f"   Clientes: {client_count}")
    print(f"   Ventas: {sale_count}")
    print(f"   Artículos de Inventario: {inventory_count}")
    
    print(f"\n🚀 Backend está listo en http://localhost:8000")
    print(f"📚 Documentación Swagger en http://localhost:8000/docs")

except Exception as e:
    print(f"❌ Error: {e}")
    import traceback
    traceback.print_exc()
finally:
    db.close()
