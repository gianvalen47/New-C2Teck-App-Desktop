"""
Configuration for the SIGECOM Backend API
"""
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
    "http://localhost:8080",
    "http://127.0.0.1:3000",
    "http://127.0.0.1:5173",
    "http://127.0.0.1:8080",
    "null",
]

# API configuration
API_V1_STR = "/api/v1"
PROJECT_NAME = "SIGECOM Backend API"
PROJECT_VERSION = "0.1.0"
