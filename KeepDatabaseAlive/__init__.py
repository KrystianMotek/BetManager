import os
import logging
from sqlalchemy import text
from azure.functions import TimerRequest
from main.database import DatabaseConnection

def main(mytimer: TimerRequest) -> None:    
    for retry in os.environ["DB_KEEP_ALIVE_RETRIES"]:
        try:
            with DatabaseConnection() as session:
                result = session.execute(text("SELECT 1")).scalar_one()
            logging.info(f"get {result} value using database connection")
            break
        except Exception as exception:
            logging.error(f"database query cannot be processed {exception}")
            continue