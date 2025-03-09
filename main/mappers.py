import pydantic
import main.models as models
from main.exceptions import *
from main.repositories import *
from main.schemas import *
from typing import Any


class BaseMapper:
    def __init__(self, dictionary_item_repository: DictionaryItemRepository):
        self._dictionary_item_repository = dictionary_item_repository
        self._dictionary_scopes = dictionary_item_repository.get_unique_scopes()
    
    def map_dictionary_item(self, scope: str, value: str) -> models.DictionaryItem:
        dictionary_item = self._dictionary_item_repository.get_by_scope_and_value(scope, value)
        if dictionary_item is None:
            raise DictionaryItemNotFoundException(scope)
        
        return dictionary_item
        
    def set_field_value(self, destination: models.BaseModel, field: str, value: Any) -> None:
        if not hasattr(destination, field):
            raise NotExistingAttributeException(type(destination), field)
        
        scope = field.title().replace("_", "")
        
        if scope in self._dictionary_scopes:
            dictionary_item = self.map_dictionary_item(scope, value)
            setattr(destination, field, dictionary_item)
        else:
            setattr(destination, field, value)
            
    def map_properties(self, schema: pydantic.BaseModel, instance: models.BaseModel, exclusions=[]) -> None:
        validated_schema = type(schema).model_validate(schema).model_dump()
        
        for key, value in validated_schema.items():
            if key in exclusions:
                continue
              
            self.set_field_value(instance, key, value)


class CouponMapper(BaseMapper):
    def __init__(self, dictionary_item_repository: DictionaryItemRepository, coupon_repository: CouponRepository, coupon_position_repository: CouponPositionRepository):
        super().__init__(dictionary_item_repository)
        self._coupon_repository = coupon_repository
        self._coupon_position_repository = coupon_position_repository
            
    def map_create_coupon_position_schema(self, schema: CreateCouponPositionDTO) -> models.CouponPosition:
        coupon_position = models.CouponPosition()
        self.map_properties(schema, coupon_position)
        
        return coupon_position
    
    def map_create_coupon_schema(self, schema: CreateCouponDTO) -> models.Coupon:
        coupon = models.Coupon()
        self.map_properties(schema, coupon, ["positions"])
        coupon.positions = [self.map_create_coupon_position_schema(position_schema) for position_schema in schema.positions]
        
        return coupon
    
    def map_update_coupon_position_schema(self, schema: UpdateCouponPositionDTO, coupon: models.Coupon) -> models.CouponPosition:
        coupon_position = self._coupon_position_repository.get_by_number(schema.position_number)
        
        if coupon_position is None:
                coupon_position = models.CouponPosition()
                coupon_position.coupon = coupon
        elif coupon_position.__getattribute__("coupon_id") != coupon.id:
            raise CouponPositionMismatchException(coupon_position.position_number, coupon.coupon_number)
                
        self.map_properties(schema, coupon_position, ["position_number"])
        
        return coupon_position
    
    def map_update_coupon_schema(self, schema: UpdateCouponDTO) -> models.Coupon:
        coupon = self._coupon_repository.get_by_number(schema.coupon_number)
        
        if coupon is None:
            raise CouponNotFoundException(schema.coupon_number)
        
        self.map_properties(schema, coupon, ["positions", "coupon_number"]) 
        coupon.positions = [self.map_update_coupon_position_schema(position, coupon) for position in schema.positions]
        
        return coupon