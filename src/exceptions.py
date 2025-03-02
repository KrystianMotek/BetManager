class CouponNotFoundException(Exception):
    def __init__(self, coupon_number: str, *args):
        super().__init__(*args)
        self.coupon_number = coupon_number


class CouponAlreadyExistsException(Exception):
    def __init__(self, coupon_number: str, *args):
        super().__init__(*args)
        self.coupon_number = coupon_number
        

class NotExistingAttributeException(Exception):
    def __init__(self, model: type, field: str, *args):
        super().__init__(*args)
        self.model = model
        self.field = field


class CouponUpdateOperationException(Exception):
    def __init__(self, message: str, *args):
        super().__init__(*args)
        self.message = message


class CouponPositionMismatchException(Exception):
    def __init__(self, position_number: int, coupon_number: str, *args):
        super().__init__(*args)
        self.position_number = position_number
        self.coupon_number = coupon_number


class DictionaryItemNotFoundException(Exception):
    def __init__(self, scope: str, *args):
        super().__init__(*args)
        self.scope = scope