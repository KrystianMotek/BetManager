import json
from datetime import date
from main.schemas import GetCouponDTO
from main.services import CouponService
from main.middlewares import handle_exceptions
from main.repositories import CouponRepository, DictionaryItemRepository
from azure.functions import HttpRequest, HttpResponse
from main.database import DatabaseConnection

@handle_exceptions
def main(req: HttpRequest) -> HttpResponse:
    with DatabaseConnection() as connection: 
        session = connection
    
    coupon_repository = CouponRepository(session)
    dictionary_item_repository = DictionaryItemRepository(session)
    
    coupon_service = CouponService(coupon_repository, dictionary_item_repository)

    start = req.params.get("start")
    end = req.params.get("end")
    
    if not start or not end:
        raise ValueError("missing required parameters")
    
    try:
        start_date = date.fromisoformat(start)
        end_date = date.fromisoformat(end)
    except ValueError:
        raise ValueError("invalid date format")
    
    coupons = coupon_service.get_coupons_by_conclusion_time_range(start_date, end_date)
    response_data = [GetCouponDTO.model_validate(coupon).model_dump() for coupon in coupons]
    
    return HttpResponse(json.dumps({"data": response_data}, default=str), mimetype="application/json")