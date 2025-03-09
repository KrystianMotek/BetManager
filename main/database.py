import os
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, Session
from azure.identity import DefaultAzureCredential

class DatabaseConnection:
    def __init__(self):
        try:
            credential = DefaultAzureCredential()
            token = credential.get_token("https://database.windows.net/.default").token.encode("UTF-16-LE")
        except Exception:
            raise RuntimeError("failed to achieve token because of not found or invalid credential")
            
        try:
            server = os.environ["DB_SERVER_NAME"]
            database = os.environ["DB_DATABASE_NAME"]
            connection_string = f"mssql+pyodbc://@{server}/{database}?driver=ODBC+Driver+18+for+SQL+Server&authentication=ActiveDirectoryMsi&AccessToken={token}"
        except KeyError:
            raise KeyError("app settings environment variables not set")
        
        try:
            engine = create_engine(connection_string)
            SessionLocal = sessionmaker(bind=engine, autoflush=False)
            self._session = SessionLocal()
        except Exception:
            raise RuntimeError("database connection failure while session creating")

    def __enter__(self) -> Session:
        return self._session

    def __exit__(self, exc_type, exc_value, tracebook) -> None:
        self._session.close()

    def get_session(self) -> Session:
        return self._session