import sys
import unittest
import uuid
from pathlib import Path

from fastapi.testclient import TestClient

sys.path.append(str(Path(__file__).resolve().parents[1]))

from config import SessionLocal
from main import app
from models import SaleModel


class SalesEmailEndpointTests(unittest.TestCase):
    def test_send_email_endpoint_marks_sale_as_sent(self):
        client = TestClient(app)
        db = SessionLocal()
        sale = SaleModel(
            id=str(uuid.uuid4()),
            type="Factura",
            series="F001",
            number=1,
            client_id="cliente@example.com",
            items=[],
            subtotal=100,
            tax=18,
            total=118,
            status="draft",
        )
        db.add(sale)
        db.commit()
        db.refresh(sale)

        try:
            response = client.post(
                f"/api/v1/sales/{sale.id}/send-email",
                json={"recipient": "cliente@example.com"},
            )
            self.assertEqual(response.status_code, 200)
            payload = response.json()
            self.assertEqual(payload["status"], "sent")
        finally:
            db.delete(sale)
            db.commit()
            db.close()


if __name__ == "__main__":
    unittest.main()
