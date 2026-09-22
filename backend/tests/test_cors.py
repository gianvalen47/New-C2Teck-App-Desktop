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


def test_login_requires_real_sigecoom_credentials(monkeypatch):
    import routers.auth as auth_module

    monkeypatch.setattr(auth_module, "is_legacy_source_enabled", lambda: False)

    client = TestClient(app)
    response = client.post(
        "/api/v1/auth/login",
        json={"username": "usuario_real", "password": "abc"},
    )

    assert response.status_code == 401
    assert "credenciales" in response.json()["detail"].lower()


def test_session_matches_legacy_systeck_exchange_rate_contract(monkeypatch):
    import routers.auth as auth_module

    def fake_validate_user(moneda: str, password: str, company_code=None):
        return {"username": "usuario_real", "perfil": "Usuario", "empresas": [{"codigo": "08", "nombre": "Empresa 08"}]}

    monkeypatch.setattr(auth_module, "validate_user_legacy", fake_validate_user)
    monkeypatch.setattr(auth_module, "fetch_tipo_cambio_legacy", lambda moneda, fecha, company_code=None: (3.36, 3.369))
    monkeypatch.setattr(auth_module, "is_legacy_source_enabled", lambda: True)

    client = TestClient(app)
    response = client.post(
        "/api/v1/auth/login",
        json={"username": "usuario_real", "password": "ClaveActual"},
    )

    assert response.status_code == 200
    payload = response.json()
    assert payload["username"] == "usuario_real"
    assert payload["perfil"] == "Usuario"
    assert payload["tipo_cambio_compra"] == 3.36
    assert payload["tipo_cambio_venta"] == 3.369


def test_session_uses_real_legacy_exchange_rate_when_adapter_provides_it(monkeypatch):
    import routers.auth as auth_module

    def fake_validate_user(username: str, password: str, company_code=None):
        return {"username": username, "perfil": "Usuario", "empresas": [{"codigo": "08", "nombre": "Empresa 08"}]}

    def fake_fetch_legacy_tipo_cambio(moneda: str, fecha: str, company_code=None):
        assert moneda == "US"
        return 3.351, 3.36

    monkeypatch.setattr(auth_module, "validate_user_legacy", fake_validate_user)
    monkeypatch.setattr(auth_module, "fetch_tipo_cambio_legacy", fake_fetch_legacy_tipo_cambio)
    monkeypatch.setattr(auth_module, "is_legacy_source_enabled", lambda: True)

    client = TestClient(app)
    response = client.post(
        "/api/v1/auth/login",
        json={"username": "usuario_real", "password": "ClaveActual"},
    )

    assert response.status_code == 200
    payload = response.json()
    assert payload["tipo_cambio_compra"] == 3.351
    assert payload["tipo_cambio_venta"] == 3.36


def test_multiempresa_and_company_switch_endpoints_work(monkeypatch):
    import routers.auth as auth_module

    def fake_validate_user(username: str, password: str, company_code=None):
        return {
            "username": username,
            "perfil": "Usuario",
            "empresas": [
                {"codigo": "08", "nombre": "Empresa 08"},
                {"codigo": "09", "nombre": "Empresa 09"},
            ],
        }

    monkeypatch.setattr(auth_module, "validate_user_legacy", fake_validate_user)
    monkeypatch.setattr(auth_module, "fetch_tipo_cambio_legacy", lambda moneda, fecha, company_code=None: (3.36, 3.369))
    monkeypatch.setattr(auth_module, "is_legacy_source_enabled", lambda: True)

    client = TestClient(app)
    login_response = client.post(
        "/api/v1/auth/login",
        json={"username": "usuario_real", "password": "ClaveActual"},
    )
    assert login_response.status_code == 200

    empresas_response = client.get("/api/v1/auth/empresas")
    assert empresas_response.status_code == 200
    empresas = empresas_response.json()
    assert [item["codigo"] for item in empresas] == ["08", "09"]

    switch_response = client.post("/api/v1/auth/cambiar-empresa", json={"codigo": "09"})
    assert switch_response.status_code == 200
    payload = switch_response.json()
    assert payload["empresa_actual"]["codigo"] == "09"
    assert payload["empresas"][1]["codigo"] == "09"
