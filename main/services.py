from uuid import UUID
from typing import List
from datetime import datetime
from sqlalchemy.exc import IntegrityError
from main.repositories import *
from main.exceptions import *
from main.models import *


class CouponService:
    def __init__(self, coupon_repository: CouponRepository, dictionary_item_repository: DictionaryItemRepository):
        self._coupon_repository = coupon_repository
        self._dictionary_item_repository = dictionary_item_repository
        
    def create_coupon(self, coupon: Coupon) -> Coupon:
        try:
            self._coupon_repository.create(coupon)
            return coupon
        except IntegrityError:
            raise CouponAlreadyExistsException(coupon.coupon_number)
        
    def update_coupon(self, coupon: Coupon) -> Coupon:
        try:
            self._coupon_repository.update(coupon)
            return coupon
        except IntegrityError:
            raise CouponUpdateOperationException("failed to update object due to data integrity")
           
    def get_by_id(self, id: UUID) -> Coupon:
        return self._coupon_repository.get_by_id(id)
    
    def get_dictionary_item_by_scope_and_value(self, scope: str, value: str) -> DictionaryItem:
        return self._dictionary_item_repository.get_by_scope_and_value(scope, value)
    
    def get_unique_dictionary_scopes(self) -> List[str]:
        return self._dictionary_item_repository.get_unique_scopes()
    
    def get_coupons_by_conclusion_time_range(self, start: datetime, end: datetime) -> List[Coupon]:
        return self._coupon_repository.get_by_conclusion_time_range(start, end)