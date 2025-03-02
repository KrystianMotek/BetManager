import json
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker, Session    


class DatabaseConnection:
    def __init__(self):
        with open("settings.json", "r") as file:
            connection_string = json.load(file)["Database"]["ConnectionString"]

        engine = create_engine(connection_string)
        SessionLocal = sessionmaker(bind=engine, autoflush=False)
        self._session = SessionLocal()
    
    def __enter__(self) -> Session:
        return self._session
    
    def __exit__(self, exc_type, exc_value, tracebook) -> None:
        return self._session.close()
    
    def get_session(self) -> Session:
        return self._session