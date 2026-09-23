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


def test_login_accepts_nested_company_payloads_from_legacy_service(monkeypatch):
    import routers.auth as auth_module

    def fake_validate_user(username: str, password: str, company_code=None):
        return {
            "username": username,
            "perfil": "Usuario",
            "result": {
                "empresas": [
                    {"codigo": "08", "nombre": "Empresa 08"},
                    {"codigo": "09", "nombre": "Empresa 09"},
                ]
            },
        }

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
    assert [item["codigo"] for item in payload["empresas"]] == ["08", "09"]
    assert payload["empresa_actual"]["codigo"] == "08"


def test_company_filter_does_not_empty_results_for_unknown_company_code():
    from routers.guias_remision import _filter_active_company

    rows = [{"id_locacion": 87, "numero": "T001-1"}, {"id_locacion": 72, "numero": "T001-2"}]

    filtered = _filter_active_company(rows, "99")

    assert filtered == rows


def test_company_filter_keeps_guides_when_company_metadata_missing_but_location_matches():
    import legacy_adapter
    from legacy_adapter import _row_matches_company

    row = {"id_locacion": 87, "numero": "T001-1"}

    assert _row_matches_company(row, "08") is True
    assert _row_matches_company(row, "05") is False


def test_list_guias_legacy_keeps_rows_without_codemp_when_location_matches(monkeypatch):
    import legacy_adapter

    rows = [{"id_locacion": 87, "num_doc": 1, "estado": "GENERADO"}]

    monkeypatch.setattr(legacy_adapter, "_read_json", lambda url: rows)
    result = legacy_adapter.list_guias_legacy(company_codes=["08"])

    assert len(result) == 1
    assert result[0]["id_locacion"] == 87
