import json 
import main.exceptions as exceptions
from azure.functions import HttpRequest, HttpResponse
from pydantic import ValidationError
from functools import wraps 

def build_error_response(status_code: int, message: str) -> HttpResponse:
    content = json.dumps({"error": message})
    
    return HttpResponse(content, status_code=status_code, mimetype="application/json") 
        
def handle_exceptions(func):
    @wraps(func)
    def wrapper(req: HttpRequest):
        try:
            return func(req)
        
        except exceptions.CouponNotFoundException as exception:
            return build_error_response(404, f"coupon {exception.coupon_number} does not exist")
        
        except exceptions.CouponPositionMismatchException as exception:
            return build_error_response(409, f"position {exception.position_number} is not corresponding to given coupon {exception.coupon_number}")
        
        except exceptions.DictionaryItemNotFoundException as exception:
            return build_error_response(422, f"cannot perform operation due to invalid {exception.scope} value")
        
        except exceptions.CouponAlreadyExistsException as exception:
            return build_error_response(409, f"coupon {exception.coupon_number} already exists")
        
        except exceptions.CouponUpdateOperationException as exception:
            return build_error_response(409, str(exception))
        
        except ValidationError as exception:
            details = []
            for error in exception.errors():
                detail = {"field": error["loc"], "message": error["msg"]}
                details.append(detail)
                
            content = json.dumps({"error": "invalid data format", "details": details})
            
            return HttpResponse(content, status_code=422, mimetype="application/json")
        
        except ValueError as exception:
            return build_error_response(400, str(exception))

        except Exception:
            return build_error_response(500, "internal server error")
            
    return wrapper