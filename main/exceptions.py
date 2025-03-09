class CouponNotFoundException(Exception):
    def __init__(self, coupon_number: str):
        super().__init__()
        self.coupon_number = coupon_number


class CouponAlreadyExistsException(Exception):
    def __init__(self, coupon_number: str):
        super().__init__()
        self.coupon_number = coupon_number
        

class NotExistingAttributeException(Exception):
    def __init__(self, model: type, field: str):
        super().__init__()
        self.model = model
        self.field = field


class CouponPositionMismatchException(Exception):
    def __init__(self, position_number: int, coupon_number: str):
        super().__init__()
        self.position_number = position_number
        self.coupon_number = coupon_number


class DictionaryItemNotFoundException(Exception):
    def __init__(self, scope: str):
        super().__init__()
        self.scope = scope
        

class CouponUpdateOperationException(Exception):
    def __init__(self, message: str):
        super().__init__(message)