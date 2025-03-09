import json
from main.services import CouponService
from main.schemas import CreateCouponDTO
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
    schema = CreateCouponDTO(**body)
    coupon = coupon_mapper.map_create_coupon_schema(schema)
    coupon_service.create_coupon(coupon)
    
    return HttpResponse(json.dumps({"data": "coupon created successfully"}), mimetype="application/json")