"""
Configuration for the SIGECOM Backend API
"""
import os
from pathlib import Path
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from sqlalchemy.ext.declarative import declarative_base

# Base directory
BASE_DIR = Path(__file__).resolve().parent

# Database configuration
DB_FILE = BASE_DIR / "empresa.db"
DATABASE_URL = f"sqlite:///{DB_FILE}"

engine = create_engine(
    DATABASE_URL,
    connect_args={"check_same_thread": False},
    echo=False  # Set to True for SQL logging
)

SessionLocal = sessionmaker(
    autocommit=False,
    autoflush=False,
    bind=engine
)

Base = declarative_base()


# CORS configuration
CORS_ORIGINS = [
    "http://localhost:3000",
    "http://localhost:5173",
    "http://localhost:5174",
    "http://localhost:8080",
    "http://127.0.0.1:3000",
    "http://127.0.0.1:5173",
    "http://127.0.0.1:5174",
    "http://127.0.0.1:8080",
    "null",
]
CORS_ALLOW_ORIGIN_REGEX = r"http://(localhost|127\.0\.0\.1):\d+"

# API configuration
API_V1_STR = "/api/v1"
PROJECT_NAME = "SIGECOM Backend API"
PROJECT_VERSION = "0.1.0"

# Source-of-truth selection. The user can switch to the original SIGECOM API
# endpoint by setting SIGECOM_DATA_SOURCE=legacy or SIGECOM_DATA_SOURCE=sigecoom.
# Default behaviour is now enforced as legacy to honour the integration demand.
#
# The VPN gateway provided by the user is a reachable public endpoint for the
# SIGECOM original product environment. The adapter that translates HTTP/API
# requests into the WCF service needs to be published under that VPN host.
SIGECOM_DATA_SOURCE = os.getenv("SIGECOM_DATA_SOURCE", "legacy").lower()
SIGECOM_LEGACY_ADAPTER_BASE_URL = os.getenv(
    "SIGECOM_LEGACY_ADAPTER_BASE_URL",
    "http://170.231.82.58:8443",
).rstrip("/")

SUPPORTED_SIGECOM_DATA_SOURCES = {"sqlite", "legacy", "sigecoom", "adapter", "wcf", "original"}
if SIGECOM_DATA_SOURCE not in SUPPORTED_SIGECOM_DATA_SOURCES:
    SIGECOM_DATA_SOURCE = "legacy"
