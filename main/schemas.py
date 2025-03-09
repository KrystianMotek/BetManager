from uuid import UUID
from typing import List
from datetime import datetime
from pydantic import BaseModel, Field
from typing_extensions import Annotated


class DictionaryItemBaseDTO(BaseModel):    
    scope: str 
    item_value: str 
    

class CouponPositionBaseDTO(BaseModel):
    description: Annotated[str, Field(max_length=120)]
    choice: Annotated[str, Field(max_length=40)] 
    odds: Annotated[float, Field(gt=0)]
    

class CouponBaseDTO(BaseModel):
    coupon_number: Annotated[str, Field(max_length=40)]
    possible_profit: Annotated[float, Field(gt=0)]
    total_odds: Annotated[float, Field(gt=0)]
    tax_amount: Annotated[float, Field(ge=0)]
    tax_rate: Annotated[float, Field(ge=0)]
    stake: Annotated[float, Field(gt=0)]
    
    conclusion_time: datetime 
    

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
    status: Annotated[str, Field(max_length=60)]
    discipline: Annotated[str, Field(max_length=60)]
    betting_type: Annotated[str, Field(max_length=60)]
    
    class Config:
        extra = "forbid"
    

class CreateCouponDTO(CouponBaseDTO):
    status: Annotated[str, Field(max_length=60)]
    coupon_type: Annotated[str, Field(max_length=60)]
    
    positions: List[CreateCouponPositionDTO]   
    
    class Config:
        extra = "forbid"
    

class UpdateCouponPositionDTO(CouponPositionBaseDTO):
    status: Annotated[str, Field(max_length=60)]
    discipline: Annotated[str, Field(max_length=60)]
    betting_type: Annotated[str, Field(max_length=60)] 
    
    position_number: int | None = None
    
    class Config:
        extra = "forbid"
    
    
class UpdateCouponDTO(CouponBaseDTO):
    status: Annotated[str, Field(max_length=60)] 
    coupon_type: Annotated[str, Field(max_length=60)]
    
    positions: List[UpdateCouponPositionDTO]
    
    class Config:
        extra = "forbid"