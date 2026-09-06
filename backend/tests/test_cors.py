import sys
from pathlib import Path

from fastapi.testclient import TestClient

sys.path.insert(0, str(Path(__file__).resolve().parents[1]))

from main import app


def test_vite_origin_is_allowed_for_api_requests():
    client = TestClient(app)

    response = client.options(
        "/api/v1/clients",
        headers={
            "Origin": "http://127.0.0.1:5174",
            "Access-Control-Request-Method": "GET",
        },
    )

    assert response.status_code == 200
    assert response.headers.get("access-control-allow-origin") == "http://127.0.0.1:5174"


def test_login_requires_three_digit_numeric_password():
    client = TestClient(app)

    response = client.post(
        "/api/v1/auth/login",
        json={"username": "grios", "password": "abc"},
    )

    assert response.status_code == 400
    assert "3 dígitos" in response.json()["detail"].lower()


def test_session_matches_legacy_systeck_exchange_rate_contract():
    client = TestClient(app)

    response = client.post(
        "/api/v1/auth/login",
        json={"username": "grios", "password": "123"},
    )

    assert response.status_code == 200
    payload = response.json()
    assert payload["username"] == "grios"
    assert payload["perfil"] == "Consultor"
    assert payload["tipo_cambio_compra"] == 3.36
    assert payload["tipo_cambio_venta"] == 3.369
