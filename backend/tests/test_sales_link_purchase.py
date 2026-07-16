import sys
import unittest
import uuid
from pathlib import Path

from fastapi.testclient import TestClient

sys.path.append(str(Path(__file__).resolve().parents[1]))

from config import SessionLocal
from main import app
from models import SaleModel


class SalesLinkPurchaseTests(unittest.TestCase):
    def test_link_purchase_endpoint_stores_reference(self):
        client = TestClient(app)
        db = SessionLocal()
        sale = SaleModel(
            id=str(uuid.uuid4()),
            type="Ingreso Almacén",
            series="IC001",
            number=1,
            client_id="Proveedor Demo",
            items=[],
            subtotal=0,
            tax=0,
            total=0,
            status="draft",
        )
        db.add(sale)
        db.commit()
        db.refresh(sale)

        try:
            response = client.post(
                f"/api/v1/sales/{sale.id}/link-purchase",
                json={"purchase_reference": "F-001-000123", "supplier": "Proveedor Demo"},
            )
            self.assertEqual(response.status_code, 200)
            payload = response.json()
            self.assertEqual(payload["extra_data"]["purchase_reference"], "F-001-000123")
            self.assertEqual(payload["extra_data"]["supplier"], "Proveedor Demo")
            self.assertEqual(payload["status"], "linked")
        finally:
            db.delete(sale)
            db.commit()
            db.close()


if __name__ == "__main__":
    unittest.main()
