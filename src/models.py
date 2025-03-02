from uuid import uuid4
from sqlalchemy import *
from datetime import datetime, timezone
from sqlalchemy.dialects.mssql import UNIQUEIDENTIFIER
from sqlalchemy.ext.declarative import as_declarative 
from sqlalchemy.orm import relationship, validates


@as_declarative()
class BaseModel:
    __table_args__ = {"implicit_returning": False}
    
    id = Column("Id", UNIQUEIDENTIFIER, primary_key=True, default=uuid4)
    
    created_at = Column("CreatedAt", DateTime, default=datetime.now(timezone.utc), nullable=False)
    
    modified_at = Column("ModifiedAt", DateTime, default=datetime.now(timezone.utc), nullable=False)
    

class DictionaryItem(BaseModel):
    __tablename__ = "DictionaryItems"
    
    scope = Column("Scope", String(60), nullable=False)
    
    item_value = Column("ItemValue", String(60), nullable=False)
    

class Coupon(BaseModel):
    __tablename__ = "Coupons"
    
    status_id = Column("StatusId", UNIQUEIDENTIFIER, ForeignKey("DictionaryItems.Id"), nullable=False)
    status = relationship("DictionaryItem", foreign_keys=[status_id], lazy="joined")
    
    coupon_type_id = Column("CouponTypeId", UNIQUEIDENTIFIER, ForeignKey("DictionaryItems.Id"), nullable=False)
    coupon_type = relationship("DictionaryItem", foreign_keys=[coupon_type_id], lazy="joined")
    
    coupon_number = Column("CouponNumber", String(40), unique=True, nullable=False)
    
    conclusion_time = Column("ConclusionTime", DateTime, nullable=False)
    
    total_odds = Column("TotalOdds", DECIMAL(10, 2), nullable=False)
    
    stake = Column("Stake", DECIMAL(10, 2), nullable=False)
    
    tax_rate = Column("TaxRate", DECIMAL(10, 4), nullable=False)
    
    tax_amount = Column("TaxAmount", DECIMAL(10, 2), nullable=False)
    
    possible_profit = Column("PossibleProfit", DECIMAL(10, 2), nullable=False)
    
    positions = relationship("CouponPosition", back_populates="coupon", cascade="all, delete-orphan")
    
    @validates("status")
    def set_status_id(self, key: str, status: DictionaryItem) -> None:
        if status:
            self.status_id = status.id
            
        return status
            
    @validates("coupon_type")
    def set_coupon_type_id(self, key: str, coupon_type: DictionaryItem) -> None:
        if coupon_type:
            self.coupon_type_id = coupon_type.id
            
        return coupon_type
    

class CouponPosition(BaseModel):
    __tablename__ = "CouponPositions"
    
    coupon_id = Column("CouponId", UNIQUEIDENTIFIER, ForeignKey("Coupons.Id"), nullable=False)
    coupon = relationship("Coupon", foreign_keys=[coupon_id], back_populates="positions")
    
    discipline_id = Column("DisciplineId", UNIQUEIDENTIFIER, ForeignKey("DictionaryItems.Id"), nullable=False)
    discipline = relationship("DictionaryItem", foreign_keys=[discipline_id], lazy="joined")
    
    betting_type_id = Column("BettingTypeId", UNIQUEIDENTIFIER, ForeignKey("DictionaryItems.Id"), nullable=False)
    betting_type = relationship("DictionaryItem", foreign_keys=[betting_type_id], lazy="joined")
    
    status_id = Column("StatusId", UNIQUEIDENTIFIER, ForeignKey("DictionaryItems.Id"), nullable=False)
    status = relationship("DictionaryItem", foreign_keys=[status_id], lazy="joined")
    
    position_number = Column("PositionNumber", Integer, Identity(start=1, increment=1), nullable=False)
    
    description = Column("Description", String(120), nullable=False)
    
    choice = Column("Choice", String(40), nullable=False)
    
    odds = Column("Odds", DECIMAL(10, 2), nullable=False)
    
    @validates("discipline")
    def set_discipline_id(self, key: str, discipline: DictionaryItem) -> None:
        if discipline:
            self.discipline_id = discipline.id 
            
        return discipline
    
    @validates("betting_type")
    def set_betting_type_id(self, key: str, betting_type: DictionaryItem) -> None:
        if betting_type:
            self.betting_type_id = betting_type.id 
            
        return betting_type
            
    @validates("status")
    def set_status_id(self, key: str, status: DictionaryItem) -> None:
        if status:
            self.status_id = status.id
            
        return status