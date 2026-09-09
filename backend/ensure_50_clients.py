from config import SessionLocal
from models import ClientModel
import uuid

db = SessionLocal()
try:
    count = db.query(ClientModel).count()
    print(f"Clientes actuales: {count}")
    target = 50
    next_index = count + 1
    while count < target:
        ruc = str(20000000000 + next_index)  # 11+ digits but unique
        client = ClientModel(
            id=str(uuid.uuid4()),
            name=f"Seed Client {next_index}",
            ruc=ruc,
            address="Seed address",
            phone="000-0000",
            email=f"seed{next_index}@example.com"
        )
        db.add(client)
        count += 1
        next_index += 1
    db.commit()
    print(f"Clientes después: {db.query(ClientModel).count()}")
except Exception as e:
    print('Error:', e)
finally:
    db.close()
