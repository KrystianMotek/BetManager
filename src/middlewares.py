from exceptions import *
from fastapi import Request
from fastapi.responses import JSONResponse
from starlette.middleware.base import BaseHTTPMiddleware
from pydantic import ValidationError


class ErrorHandlingMiddleware(BaseHTTPMiddleware):
    @staticmethod    
    def _create_response(status_code: int, message: str):
        return JSONResponse(status_code=status_code, content={"error": message})
        
    async def dispatch(self, request: Request, call_next):
        try:
            response = await call_next(request)
            return response
        except ValidationError:
            return self._create_response(422, "invalid request body format")
        except CouponAlreadyExistsException as exception:
            return self._create_response(409, "coupon {} already exists".format(exception.coupon_number))
        except CouponNotFoundException as exception:
            return self._create_response(404, "coupon {} does not exist".format(exception.coupon_number))
        except CouponPositionMismatchException as exception:
            return self._create_response(409, "position {} is not corresponding to given coupon {}".format(exception.position_number, exception.coupon_number))
        except DictionaryItemNotFoundException as exception:
            return self._create_response(422, "cannot perform operation due to invalid {} value".format(exception.scope))
        except CouponUpdateOperationException as exception:
            return self._create_response(409, exception.message)