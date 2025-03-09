import json
from main.services import CouponService
from main.schemas import UpdateCouponDTO
from main.middlewares import handle_exceptions
from main.repositories import CouponRepository, CouponPositionRepository, DictionaryItemRepository
from azure.functions import HttpRequest, HttpResponse
from main.database import DatabaseConnection
from main.mappers import CouponMapper

@handle_exceptions
def main(req: HttpRequest) -> HttpResponse:
    with DatabaseConnection() as connection: 
        session = connection
    
    coupon_repository = CouponRepository(session)
    coupon_position_repository = CouponPositionRepository(session)
    dictionary_item_repository = DictionaryItemRepository(session)
    
    coupon_service = CouponService(coupon_repository, dictionary_item_repository)
    coupon_mapper = CouponMapper(dictionary_item_repository, coupon_repository, coupon_position_repository)

    body = req.get_json()
    schema = UpdateCouponDTO(**body)
    coupon = coupon_mapper.map_update_coupon_schema(schema)
    coupon_service.update_coupon(coupon)
    
    return HttpResponse(json.dumps({"data": "coupon updated successfully"}), mimetype="application/json")