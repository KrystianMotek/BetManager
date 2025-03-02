from uuid import UUID
from typing import List
from datetime import datetime
from pydantic import BaseModel


class DictionaryItemBaseDTO(BaseModel):    
    scope: str 
    item_value: str 
    

class CouponPositionBaseDTO(BaseModel):
    description: str 
    choice: str 
    odds: float 
    

class CouponBaseDTO(BaseModel):
    coupon_number: str 
    conclusion_time: datetime 
    possible_profit: float
    total_odds: float
    tax_amount: float
    tax_rate: float
    stake: float
    

class GetDictionaryItemDTO(DictionaryItemBaseDTO):
    id: UUID 
    
    class Config:
        from_attributes = True
    
    
class GetCouponPositionDTO(CouponPositionBaseDTO):
    id: UUID
    created_at: datetime
    modified_at: datetime
    
    position_number: int
    
    status: GetDictionaryItemDTO
    discipline: GetDictionaryItemDTO
    betting_type: GetDictionaryItemDTO
    
    class Config:
        from_attributes = True
        extra = "forbid"
    

class GetCouponDTO(CouponBaseDTO):
    id: UUID
    created_at: datetime
    modified_at: datetime
    
    status: GetDictionaryItemDTO 
    coupon_type: GetDictionaryItemDTO
    
    positions: List[GetCouponPositionDTO]
    
    class Config:
        from_attributes = True
        extra = "forbid"
    

class CreateCouponPositionDTO(CouponPositionBaseDTO):
    status: str 
    discipline: str 
    betting_type: str 
    
    class Config:
        extra = "forbid"
    

class CreateCouponDTO(CouponBaseDTO):
    status: str 
    coupon_type: str 
    
    positions: List[CreateCouponPositionDTO]   
    
    class Config:
        extra = "forbid"
    

class UpdateCouponPositionDTO(CouponPositionBaseDTO):
    status: str 
    discipline: str 
    betting_type: str 
    
    position_number: int | None = None
    
    class Config:
        extra = "forbid"
    
    
class UpdateCouponDTO(CouponBaseDTO):
    status: str 
    coupon_type: str 
    
    positions: List[UpdateCouponPositionDTO]
    
    class Config:
        extra = "forbid"