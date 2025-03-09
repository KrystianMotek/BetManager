import pyodbc
from uuid import UUID
from datetime import datetime
from sqlalchemy.future import select
from sqlalchemy.exc import IntegrityError
from typing import Type, Optional, List
from sqlalchemy.orm import Session
from main.models import *


class BaseRepository:
    def __init__(self, session: Session, model: Type[BaseModel]):
        self._session = session
        self._model = model
        
    def create(self, instance: BaseModel) -> BaseModel:
        try:
            self._session.add(instance)
            self._session.commit()
            return instance
        except IntegrityError:
            self._session.rollback()
            raise IntegrityError(None, None, pyodbc.IntegrityError)
        
    def update(self, instance: BaseModel) -> BaseModel:        
        try:
            self._session.commit()
            return instance
        except IntegrityError:
            self._session.rollback()
            raise IntegrityError(None, None, pyodbc.IntegrityError) 
        
    def get_by_id(self, id: UUID) -> Optional[BaseModel]:
        return self._session.get(self._model, id)     
        

class DictionaryItemRepository(BaseRepository):
    def __init__(self, session: Session):
        super().__init__(session, model=DictionaryItem)
        
    def get_by_scope_and_value(self, scope: str, value: str) -> DictionaryItem:
        query = select(DictionaryItem).where((DictionaryItem.scope == scope) & (DictionaryItem.item_value == value))
        
        return self._session.execute(query).scalar_one_or_none()
        
    def get_unique_scopes(self) -> List[str]:
        query = select(DictionaryItem.scope).distinct()
        
        return self._session.execute(query).scalars().all()
        

class CouponRepository(BaseRepository):
    def __init__(self, session):
        super().__init__(session, model=Coupon)  
        
    def get_by_number(self, number: str) -> Optional[Coupon]:
        query = select(Coupon).where((Coupon.coupon_number == number))
        
        return self._session.execute(query).scalar_one_or_none()
        
    def get_by_conclusion_time_range(self, start: datetime, end: datetime) -> List[Coupon]:
        query = select(Coupon).where((Coupon.conclusion_time >= start) & (Coupon.conclusion_time <= end))
        
        return self._session.execute(query).scalars().all()
    

class CouponPositionRepository(BaseRepository):
    def __init__(self, session: Session):
        super().__init__(session, model=CouponPosition)
        
    def get_by_number(self, number: int) -> Optional[CouponPosition]:
        query = select(CouponPosition).where(CouponPosition.position_number == number)
        
        return self._session.execute(query).scalar_one_or_none()