using BetManager.Domain.Models;

using namespace BetManager.Application.Models.Mappers
{   
    public interface ICouponMapper
    {
        public Coupon MapToCoupon<T>(T dto);
        public CouponPosition MapToCouponPosition<T>(T dto);
        public GetCouponDTO MapCouponToDTO(Coupon coupon);
        public GetCouponPositionDTO MapCouponPositionToDTO(CouponPosition couponPosition);
        private void MapProperties<TSource, TDestination>(TSource source, TDestination destination);
    }
}